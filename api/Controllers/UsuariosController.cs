using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly AdminContext _context;
        public UsuariosController(IConfiguration config, AdminContext context)
        {
            _config = config;
             _context = context;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] UsuariosLogin usuarioLogin)
        {
            var usuario = AutenticarUsuario(usuarioLogin);

            if (usuario == null)
                return Unauthorized("Credenciales incorrectas");

            var token = GenerarTokenJWT(usuario);
            return Ok(new { token, usuario });
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<usuarios>>> GetUsuarios()
        {
            return await _context.usuarios.ToListAsync();
        }

        // Obtener un usuario por ID
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<usuarios>> GetUsuario(int id)
        {
            var usuario = await _context.usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return usuario;
        }

        // Crear un nuevo usuario
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<usuarios>> PostUsuario(usuarios usuario)
        {
            _context.usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.usuarioid }, usuario);
        }

        // Actualizar un usuario existente
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutUsuario(int id, usuarios usuario)
        {
            if (id != usuario.usuarioid)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // Eliminar un usuario
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(int id)
        {
            return _context.usuarios.Any(e => e.usuarioid == id);
        }

        private usuarios? AutenticarUsuario(UsuariosLogin usuarioLogin)
        {
            
            var usuario = _context.usuarios.Where(o=>o.email.ToUpper() ==usuarioLogin.Email.ToUpper() && o.contrasena==usuarioLogin.Contrasena).FirstOrDefault();
            // Aquí debes verificar las credenciales contra la base de datos.
            // Esta es una versión simplificada.
            if (usuario!= null)
                return usuario;

            return null;
        }

        private string GenerarTokenJWT(usuarios usuario)
        {
            var key = _config["Jwt:Key"];
            if (string.IsNullOrEmpty(key))
            {
                throw new InvalidOperationException("La clave JWT no está configurada.");
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, usuario.email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("nombre", usuario.nombre)
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(Convert.ToUInt32(_config["Jwt:timer"])),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
