namespace api.Core.Parametrizacion.Movements.Response;

public record MovementResponse
{
    public int id { get; set; }

    public string tipomovimiento { get; set; }

    public int cantidad { get; set; }

    public DateTime fecha { get; set; }

    public int idproducto { get; set; }

    public string? NombreProducto { get; set; }

    public int idusuario { get; set; }

    public string? NombreUsuario { get; set; }
}