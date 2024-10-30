namespace api.Core.Parametrizacion.Producto.Response
{
    public record ProductoDetallado(int Id,
    string Nombre,
    string Descripcion,
    decimal Precio,
    int Stock);
}