using api.Core.Parametrizacion.ProductAggregate.Request;
using api.Core.Parametrizacion.ProductAggregate.Response;
using api.Models;
using api.Models.Parametrizacion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly AdminContext _context;

        [HttpPost]
        public async Task<IActionResult> CreateProducto([FromBody] CrearProducto spec)
        {
            if (!spec.ValidarProducto(out var errors))
            {
                return BadRequest(errors);
            }

            var producto = new Producto
            {
                Nombre = spec.Nombre!,
                Descripcion = spec.Descripcion!,
                Stock = (int)spec.Stock!,
                Precio = (decimal)spec.Precio!
            };

            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProducto), new { id = producto.Id }, producto);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductos()
        {
            var productos = await _context.Productos
                .Select(p => new ProductoDetallado(p.Id, p.Nombre, p.Descripcion, p.Precio, p.Stock))
                .ToListAsync();

            return Ok(productos);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetProducto(int id)
        {
            var producto = await _context.Productos
                .Where(p => p.Id == id)
                .Select(p => new ProductoDetallado(p.Id, p.Nombre, p.Descripcion, p.Precio, p.Stock))
                .FirstOrDefaultAsync();

            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProducto([FromHeader] int? id, [FromBody] EditarProducto spec)
        {
            if (!id.HasValue)
            {
                return BadRequest("Debe indicar un identificado para editar.");
            }

            if (!spec.ValidarProducto(out var errors))
            {
                return BadRequest(errors);
            }

            var product = _context.Productos.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return BadRequest("No se encontro un producto con el identificador suministrado.");
            }

            product.Nombre = spec.Nombre!;
            product.Descripcion = spec.Descripcion!;
            product.Precio = (decimal)spec.Precio!;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Productos.Any(e => e.Id == id))
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }
    }
}