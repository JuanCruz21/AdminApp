namespace api.Models.Cuenta;

/// <summary>
///     Clase base para el inicio de sesión de los usuarios
/// </summary>
public class UsuarioLogin
{
    /// <summary>
    ///     Correo electrónico
    /// </summary>
    public string Email { get; set; } = null!;

    /// <summary>
    ///     Contraseña del usuario
    /// </summary>
    public string Password { get; set; } = null!;
}