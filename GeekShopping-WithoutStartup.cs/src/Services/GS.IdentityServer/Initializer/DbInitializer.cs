using GS.IdentityServer.Model;
using GS.IdentityServer.Model.Context;
using GS.IdentityServer.Configuration;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using IdentityModel;

namespace GS.IdentityServer.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly MySqlContext _context;
        private readonly UserManager<ApplicationUser> _user;
        private readonly RoleManager<IdentityRole> _role;

        public DbInitializer(MySqlContext context, UserManager<ApplicationUser> user, RoleManager<IdentityRole> role)
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

            var admin = new ApplicationUser()
            {
                UserName = "allan-admin",
                Email = "allanhenriquegdacosta@hotmail.com",
                EmailConfirmed = true,
                PhoneNumber = "+55 (43) 998491365",
                FirstName = "Allan",
                Lastname = "Admin"
            };

            _user.CreateAsync(admin, "Teste@123").GetAwaiter().GetResult();

            _user.AddToRoleAsync(admin, IdentityConfiguration.Admin).GetAwaiter().GetResult();

            var adminClaims = _user.AddClaimsAsync(admin, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, $"{admin.FirstName} {admin.Lastname}"),
                new Claim(JwtClaimTypes.GivenName, admin.FirstName),
                new Claim(JwtClaimTypes.FamilyName, admin.Lastname),
                new Claim(JwtClaimTypes.Role, IdentityConfiguration.Admin)
            }).Result;

            var client = new ApplicationUser()
            {
                UserName = "allan-client",
                Email = "allanhenriquegdacostaclient@hotmail.com",
                EmailConfirmed = true,
                PhoneNumber = "+55 (43) 998491365",
                FirstName = "Allan",
                Lastname = "client"
            };

            _user.CreateAsync(client, "Teste@123").GetAwaiter().GetResult();

            _user.AddToRoleAsync(client, IdentityConfiguration.Client).GetAwaiter().GetResult();

            var clientClaims = _user.AddClaimsAsync(client, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, $"{client.FirstName} {client.Lastname}"),
                new Claim(JwtClaimTypes.GivenName, client.FirstName),
                new Claim(JwtClaimTypes.FamilyName, client.Lastname),
                new Claim(JwtClaimTypes.Role, IdentityConfiguration.Client)
            }).Result;
        }
    }
}
