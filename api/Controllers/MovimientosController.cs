using api.Core.Parametrizacion.Movements.Request;
using api.Core.Parametrizacion.Movements.Response;
using api.Models;
using api.Models.Comercial;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovimientosController : ControllerBase
    {
        private readonly AdminContext _context;

        public MovimientosController(AdminContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostMovimiento([FromBody] CrearMovimiento movimiento)
        {
            var product = await _context.productos.FirstOrDefaultAsync();

            if (product == null)
            {
                return BadRequest("Producto no encontrado");
            }

            if (movimiento.Cantidad > product.cantidad &&
                movimiento is { Cantidad: > 0, Tipomovimiento: (int)TipoMovimiento.Salida })
            {
                return BadRequest("El stock del producto no permite realizar el movimiento");
            }

            var mov = new Movimiento
            {
                Tipomovimiento = (TipoMovimiento)movimiento.Tipomovimiento,
                Cantidad = movimiento.Cantidad,
                Idproducto = movimiento.Idproducto,
                Idusuario = movimiento.Idusuario
            };

            if (movimiento.Tipomovimiento == (int)TipoMovimiento.Salida)
            {
                product.cantidad -= movimiento.Cantidad;
            }
            else
            {
                product.cantidad += movimiento.Cantidad;
            }

            _context.movimientos.Add(mov);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetMovimiento", new { id = mov.Idproducto }, movimiento);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetMovimientos()
        {
            var movimientos = await _context.movimientos
                .Include(m => m.Usuario)
                .Include(m => m.Producto)
                .Select(m => new MovementResponse
                {
                    id = m.Idproducto,
                    tipomovimiento =
                        m.Tipomovimiento.ToString(),
                    cantidad = m.Cantidad,
                    fecha = m.Fecha,
                    idproducto = m.Producto.productoid,
                    NombreProducto = m.Producto.nombre,
                    idusuario = m.Usuario.Usuarioid,
                    NombreUsuario = m.Usuario.Nombre
                })
                .ToListAsync();

            return Ok(movimientos);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetMovimiento(int id)
        {
            var movimiento = await _context.movimientos
                .Include(m => m.Usuario)
                .Include(m => m.Producto)
                .Where(m => m.Idproducto == id)
                .Select(m => new MovementResponse
                {
                    id = m.Idproducto,
                    tipomovimiento = m.Tipomovimiento.ToString(),
                    cantidad = m.Cantidad,
                    fecha = m.Fecha,
                    idproducto = m.Producto.productoid,
                    NombreProducto = m.Producto.nombre,
                    idusuario = m.Usuario.Usuarioid,
                    NombreUsuario = m.Usuario.Nombre
                })
                .FirstOrDefaultAsync();

            if (movimiento == null)
            {
                return NotFound();
            }

            return Ok(movimiento);
        }


        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutMovimiento([FromHeader] int? id, EditarMovimiento movimiento)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }

            var mov = await _context.movimientos.FirstOrDefaultAsync(i => i.Movimientoid == id);

            if (mov == null)
            {
                return BadRequest("Movimiento no encontrado");
            }

            mov.Cantidad = movimiento.Cantidad;
            mov.Tipomovimiento = (TipoMovimiento)movimiento.Tipomovimiento;
            mov.Idproducto = movimiento.Idproducto;
            mov.Idusuario = movimiento.Idusuario;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteMovimiento(int id)
        {
            var movimiento = await _context.movimientos.FindAsync(id);
            if (movimiento == null)
            {
                return NotFound();
            }

            _context.movimientos.Remove(movimiento);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}