using Microsoft.AspNetCore.Identity;

namespace GS.IdentityServer.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string Lastname { get; set; }
    }
}
