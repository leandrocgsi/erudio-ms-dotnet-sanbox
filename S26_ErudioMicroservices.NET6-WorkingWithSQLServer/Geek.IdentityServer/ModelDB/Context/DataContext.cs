using Geek.IdentityServer.ModelDB.Context;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GeekShop.IdentityServer.Model.Context
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    }
}

