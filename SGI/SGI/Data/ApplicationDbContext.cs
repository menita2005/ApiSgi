using SGI.Models;
using Microsoft.EntityFrameworkCore;
namespace SGI.Data;
public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Proveedor> Proveedor { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Venta> Venta { get; set; }
        public DbSet<Compra> Compra { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<CompraItem> CompraItem { get; set; }
        public DbSet<VentaItem> VentaItem { get; set; }
}

