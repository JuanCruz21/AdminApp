using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using api.Models.Cuenta;
using api.Models.Parametrizacion;

namespace api.Models.Comercial;

public class Movimiento
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public TipoMovimiento Tipo { get; set; }

    public int Cantidad { get; set; }

    public DateTime Fecha { get; set; }

    public int IdProducto { get; set; }

    public int IdUsuario { get; set; }

    [ForeignKey("IdProducto")] public virtual Producto Producto { get; set; } = null!;

    [ForeignKey("IdUsuario")] public virtual Usuario Usuario { get; set; } = null!;
}