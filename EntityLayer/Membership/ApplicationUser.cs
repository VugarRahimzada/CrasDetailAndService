using Microsoft.AspNetCore.Identity;

namespace EntityLayer.Membership
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}