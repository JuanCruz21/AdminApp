using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models.Cuenta;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class AdminContext : DbContext
    {
        public AdminContext(DbContextOptions<AdminContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Movimientos> movimientos { get; set; }
        public DbSet<Productos> productos { get; set; }
    }
}