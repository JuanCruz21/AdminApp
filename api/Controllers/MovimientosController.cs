using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Core.Parametrizacion.Movements.Response;
using api.Models;
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

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetMovimientos()
        {
            var movimientos = await _context.movimientos.Include(m => m.Usuario).Include(m => m.Producto).ToListAsync();
            return Ok(movimientos);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetMovimiento(int id)
        {
            var movimiento = await _context.movimientos.FindAsync(id);
            if (movimiento == null)
            {
                return NotFound();
            }

            return Ok(movimiento);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostMovimiento(Movimientos movimiento)
        {
            _context.movimientos.Add(movimiento);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetMovimiento", new { id = movimiento.Movimientoid }, movimiento);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutMovimiento(int id, Movimientos movimiento)
        {
            if (id != movimiento.Movimientoid)
            {
                return BadRequest();
            }

            _context.Entry(movimiento).State = EntityState.Modified;
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