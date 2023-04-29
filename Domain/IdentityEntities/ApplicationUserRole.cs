using Microsoft.AspNetCore.Identity;

namespace Domain.IdentityEntities
{
    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public ApplicationUser applicationUser  { get; set; }
        public ApplicationRole applicationRole { get; set; }
    }
}