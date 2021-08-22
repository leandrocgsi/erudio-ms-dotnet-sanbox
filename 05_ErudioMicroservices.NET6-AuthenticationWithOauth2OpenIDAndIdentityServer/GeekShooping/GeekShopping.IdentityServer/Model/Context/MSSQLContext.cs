using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.IdentityServer.Model.Context
{
    public class MSSQLContext : IdentityDbContext<ApplicationUser>
    {
        public MSSQLContext()
        {

        }
        public MSSQLContext(DbContextOptions<MSSQLContext> options)
            : base(options) { }
    }
}
