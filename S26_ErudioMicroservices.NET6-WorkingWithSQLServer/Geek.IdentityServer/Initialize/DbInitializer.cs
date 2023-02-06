using Geek.IdentityServer.Configuration;
using Geek.IdentityServer.ModelDB.Context;
using GeekShop.IdentityServer.Model.Context;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace GeekShop.IdentityServer.Initialize
{
    public class DbInitializer : IDbInitializer
    {
        private readonly DataContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(DataContext dbContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager; 
        }

        public void Initialize()
        {
            if (_roleManager.FindByNameAsync(IdentityConfiguration.Admin).Result != null) return;
           
            _roleManager.CreateAsync(new IdentityRole(IdentityConfiguration.Admin)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(IdentityConfiguration.Client)).GetAwaiter().GetResult();

            ApplicationUser admin = new ApplicationUser()
            {
                UserName = "delimarenata",
                Email = "renata.lima@bee-eng.pt",
                EmailConfirmed = true,
                PhoneNumber = "+351 934727285",
                FirstName = "Renata",
                LastName = "Admin"
            };

            _userManager.CreateAsync(admin, "d3Lim@1406").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(admin,IdentityConfiguration.Admin).GetAwaiter().GetResult();

            var adminClaims = _userManager.AddClaimsAsync(admin, new Claim[] 
            {
                new Claim(JwtClaimTypes.Name, $"{admin.FirstName} {admin.LastName}" ),
                new Claim(JwtClaimTypes.GivenName, admin.FirstName),
                new Claim(JwtClaimTypes.FamilyName, admin.LastName),
                new Claim(JwtClaimTypes.Role, IdentityConfiguration.Admin)

            }).Result;

            ApplicationUser client = new ApplicationUser()
            {
                UserName = "renataClient",
                Email = "rx.lima@gmail.com",
                EmailConfirmed = true,
                FirstName = "Renata",
                LastName = "Client"            
            };

            _userManager.CreateAsync(client, "d3Lim@1406").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(client, IdentityConfiguration.Client).GetAwaiter().GetResult();

            var clientClaims = _userManager.AddClaimsAsync(client, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, $"{client.FirstName} {client.LastName}"),
                new Claim(JwtClaimTypes.GivenName, client.FirstName),
                new Claim(JwtClaimTypes.FamilyName, client.LastName),
                new Claim(JwtClaimTypes.Role, IdentityConfiguration.Client)

            }).Result;
        }
    }
}
