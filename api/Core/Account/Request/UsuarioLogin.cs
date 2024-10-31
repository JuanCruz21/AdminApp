namespace api.Core.Account.Request;

public class UsuarioLogin
{
    public string Email { get; set; } = null!;

    public string Contrasena { get; set; } = null!;
}