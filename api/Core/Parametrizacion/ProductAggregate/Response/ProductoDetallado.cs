namespace api.Core.Parametrizacion.ProductAggregate.Response;

public record ProductoDetallado(int Id, string Nombre, string Descripcion, decimal Precio, int Stock);