using Microsoft.AspNetCore.Identity;

namespace Geek.IdentityServer.ModelDB.Context
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }  = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
