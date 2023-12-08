using SGI.Models;
using Microsoft.EntityFrameworkCore;
namespace SGI.Data;
public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Proveedores> Proveedores { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Ventas> Ventas { get; set; }
        public DbSet<Compras> Compras { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
    }

