using GeekShopping.ProductAPI.Implementation.Model.Class;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Implementation.Model.Context
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.ApplyConfiguration(new ProductConfiguration());

            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        }
    }

    
}
