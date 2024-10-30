using System.ComponentModel.DataAnnotations;

namespace api.Models.Cuenta;

public class Usuario : UsuarioLogin
{
    [Key] public int Id { get; set; }

    [Required] public string Nombre { get; set; } = null!;
}