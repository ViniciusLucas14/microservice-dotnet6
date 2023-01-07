using GeekShopping.IdentityServer.Model.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GeekShopping.IdentityServer.Model.ContextFactory
{
    public class ContextFactory : IDesignTimeDbContextFactory<SqlContext>
    {
        public SqlContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SqlContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=geek_shopping_identity_server;User Id=DESKTOP-6CJONAV" +
                "\\Vinicius;Password='';Trusted_Connection=Yes;");
            return new SqlContext(optionsBuilder.Options);
        }
    }
}
