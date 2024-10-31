using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Models
{

    public enum TipoMovimiento { Ingreso, Salida }
    public class Movimientos
    {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int  movimientoid{ get; set; }
    public string tipomovimiento { get; set; } = string.Empty;
    public int cantidad { get; set; }
    public DateTime fecha { get; set; }
    public int idproducto { get; set; }
    public int idusuario { get; set; }
    [ForeignKey("idproducto")] public virtual Productos Producto { get; set; } = null!;
    [ForeignKey("idusuario")] public virtual usuarios Usuario { get; set; } = null!;
    }
}