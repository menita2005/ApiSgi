using SGI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SGI.Data;
public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }

        public DbSet<Proveedor> Proveedor { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Venta> Venta { get; set; }
        public DbSet<Compra> Compra { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<CompraItem> CompraItem { get; set; }
        public DbSet<VentaItem> VentaItem { get; set; } 
        public DbSet<AppUser> AppUser { get; set; }
}

