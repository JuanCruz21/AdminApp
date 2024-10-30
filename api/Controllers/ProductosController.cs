using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Core.Parametrizacion.Producto.Request;
using api.Core.Parametrizacion.Producto.Response;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly AdminContext _context;

        public ProductosController(AdminContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProducto([FromBody] CrearProducto spec)
        {
            // if (!spec.ValidarProducto(out var errors))
            // {
            //     return BadRequest(errors);
            // }

            var producto = new Productos
            {
                nombre = spec.Nombre!,
                descripcion = spec.Descripcion!,
                cantidad = (int)spec.Cantidad!,
                precio = (decimal)spec.Precio!
            };

            _context.productos.Add(producto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProducto), new { id = producto.productoid }, producto);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductos()
        {
            var productos = await _context.productos
                .Select(p => new ProductoDetallado(p.productoid, p.nombre, p.descripcion, p.precio, p.cantidad))
                .ToListAsync();

            return Ok(productos);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetProducto(int id)
        {
            var producto = await _context.productos
                .Where(p => p.productoid == id)
                .Select(p => new ProductoDetallado(p.productoid, p.nombre, p.descripcion, p.precio, p.cantidad))
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

            var product = _context.productos.FirstOrDefault(p => p.productoid == id);

            if (product == null)
            {
                return BadRequest("No se encontro un producto con el identificador suministrado.");
            }

            product.nombre = spec.Nombre!;
            product.descripcion = spec.Descripcion!;
            product.precio = (decimal)spec.Precio!;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.productos.Any(e => e.productoid == id))
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var producto = await _context.productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            _context.productos.Remove(producto);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
