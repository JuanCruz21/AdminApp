namespace api.Core.Parametrizacion.Movements.Response;

public record MovementResponse
{
    public int movimientoid { get; set; }

    public string tipomovimiento { get; set; }

    public int cantidad { get; set; }

    public DateTime fecha { get; set; }

    public int idproducto { get; set; }

    public int idusuario { get; set; }
}