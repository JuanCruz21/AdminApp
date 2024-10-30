using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Core.Parametrizacion.Producto.Request
{
    public class CrearProducto
    {
        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }

        public decimal? Precio { get; set; }

        public int? Cantidad { get; set; }

    /// <summary>
    ///     Valida los datos del producto
    /// </summary>
    /// <param name="error">Si se presente un error en la validación, esta variable devuelve el mensaje</param>
    /// <returns>True = Validación exitosa; False = Validación presento un error;</returns>
    public bool ValidarProducto(out string error)
    {
        if (string.IsNullOrEmpty(Nombre))
        {
            error = "El nombre de producto no puede estar vacio.";
            return false;
        }

        if (string.IsNullOrEmpty(Descripcion))
        {
            error = "La  descripción del producto no puede estar vacia.";
            return false;
        }

        if (Precio <= 0)
        {
            error = "El precio del producto no puede estar vacio.";
            return false;
        }

        if (!Cantidad.HasValue)
        {
            Cantidad = 0;
        }

        error = "";
        return true;
    }
    }
}