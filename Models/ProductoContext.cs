using Microsoft.EntityFrameworkCore;

namespace pc3.Models
{
    public class ProductoContext : DbContext
        {
            public DbSet<Producto> Productos { get; set; }
            public DbSet<Categoria> Categorias { get; set; }

            public ProductoContext(DbContextOptions dco) : base(dco){
        }
    }
}