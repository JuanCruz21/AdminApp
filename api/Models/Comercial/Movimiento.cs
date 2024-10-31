using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using api.Models.Cuenta;

namespace api.Models.Comercial;

public class Movimiento
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Movimientoid { get; set; }

    public TipoMovimiento Tipomovimiento { get; set; }

    public int Cantidad { get; set; }

    public DateTime Fecha { get; set; }

    public int Idproducto { get; set; }

    public int Idusuario { get; set; }
    [ForeignKey("Idproducto")] public virtual Productos Producto { get; set; } = null!;
    [ForeignKey("Idusuario")] public virtual Usuario Usuario { get; set; } = null!;
}