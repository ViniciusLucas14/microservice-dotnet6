using GeekShopping.IdentityServer.Configuration;
using GeekShopping.IdentityServer.Model;
using GeekShopping.IdentityServer.Model.Context;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace GeekShopping.IdentityServer.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly SqlContext _context; 
        private readonly UserManager<ApplicationUser> _user;
        private readonly RoleManager<IdentityRole> _role;

        public DbInitializer(SqlContext context, UserManager<ApplicationUser> user, RoleManager<IdentityRole> role)
        {
            _context = context;
            _user = user;
            _role = role;
        }

        public void Initialize()
        {
            if (_role.FindByNameAsync(IdentityConfiguration.Admin).Result != null) return;

            _role.CreateAsync(new IdentityRole(IdentityConfiguration.Admin)).GetAwaiter().GetResult();
            _role.CreateAsync(new IdentityRole(IdentityConfiguration.Client)).GetAwaiter().GetResult();

            ApplicationUser admin = new ApplicationUser()
            {
                UserName = "Vinicius-admin",
                FirstName = "Vinicius",
                LastName = "Admin",
                Email = "vlucassouza@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "+55 (14) 99811-9831",
            };
            _user.CreateAsync(admin, "Luca$578").GetAwaiter().GetResult();  
            _user.AddToRoleAsync(admin, IdentityConfiguration.Admin).GetAwaiter().GetResult();

            var adminClaims = _user.AddClaimsAsync(admin, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, admin.FirstName),
                new Claim(JwtClaimTypes.GivenName, admin.UserName),
                new Claim(JwtClaimTypes.FamilyName, admin.LastName),
                new Claim(JwtClaimTypes.Role, IdentityConfiguration.Admin),
            }).Result; 
            
            ApplicationUser client = new ApplicationUser()
            {
                UserName = "Vinicius-client",
                FirstName = "Vinicius",
                LastName = "Client",
                Email = "vlucassouzaclient@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "+55 (14) 99811-9831",
            };
            _user.CreateAsync(client, "Luca$578").GetAwaiter().GetResult();  
            _user.AddToRoleAsync(client, IdentityConfiguration.Client).GetAwaiter().GetResult();

            var clientClaims = _user.AddClaimsAsync(client, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, client.FirstName),
                new Claim(JwtClaimTypes.GivenName, client.UserName),
                new Claim(JwtClaimTypes.FamilyName, client.LastName),
                new Claim(JwtClaimTypes.Role, IdentityConfiguration.Client),
            }).Result;
        }
    }
}
