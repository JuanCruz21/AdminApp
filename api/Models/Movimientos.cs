using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Models
{
    public class Movimientos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public enum TipoMovimiento { Ingreso, Egreso }
        public TipoMovimiento Tipo { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }
        public int IdProducto { get; set; }
        [ForeignKey("IdProducto")]
        public required Productos productos { get; set; }
        public int IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public required Usuarios usuarios { get; set; }
    }
}