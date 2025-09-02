using Microsoft.EntityFrameworkCore;
using Tienda.Models;

namespace Tienda.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet para productos
        public DbSet<Producto> Productos { get; set; } = null!;

        // Otros DbSets si tienes más entidades
        public DbSet<Pedido> Pedidos { get; set; } = null!;
    }
}
