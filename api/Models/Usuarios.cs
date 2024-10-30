using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Usuarios
    {
        [Key]
        public int usuarioid { get; set; }
        public string nombre { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string contrasena { get; set; } = string.Empty;
    }
    
    public class UsuariosLogin
    {
        public string Email { get; set; } = string.Empty;
        public string Contrasena { get; set; } = string.Empty;
    }
}