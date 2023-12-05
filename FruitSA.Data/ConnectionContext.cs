using FruitSA.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace FruitSA.Data
{
#nullable disable
    public class ConnectionContext : DbContext
    {
        public ConnectionContext(DbContextOptions<ConnectionContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
    }
}
