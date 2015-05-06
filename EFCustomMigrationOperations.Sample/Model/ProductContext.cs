using System.Data.Entity;

namespace EFCustomMigrationOperations.Sample.Model
{
    public class ProductContext : DbContext
    {
        public ProductContext() : base("DefaultConnection")
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
