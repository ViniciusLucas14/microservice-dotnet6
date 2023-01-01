using GeekShopping.ProductAPI.Implementation.Model.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GeekShopping.ProductAPI.Implementation.Model.ContextFactory
{
    public class ContextFactory : IDesignTimeDbContextFactory<SqlContext>
    {
        public SqlContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SqlContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=geek_shopping_product_api;User Id=DESKTOP-6CJONAV" +
                "\\Vinicius;Password='';Trusted_Connection=Yes;");
            return new SqlContext(optionsBuilder.Options);
        }
    }
}
