using api.Models.Comercial;
using api.Models.Cuenta;
using api.Models.Parametrizacion;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

public class AdminContext : DbContext
{
    public AdminContext(DbContextOptions<AdminContext> options) : base(options)
    {
    }

    public DbSet<Usuario> Usuarios { get; set; }

    public DbSet<Movimiento> Movimientos { get; set; }

    public DbSet<Producto> Productos { get; set; }
}