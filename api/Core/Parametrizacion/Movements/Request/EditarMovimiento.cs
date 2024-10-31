namespace api.Core.Parametrizacion.Movements.Request;

public class EditarMovimiento
{
    public int Tipomovimiento { get; set; }

    public int Cantidad { get; set; }

    public int Idproducto { get; set; }

    public int Idusuario { get; set; }
}