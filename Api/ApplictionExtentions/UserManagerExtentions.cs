using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Domain.IdentityEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Api.ApplictionExtentions
{
    public static class UserManagerExtentions
    {
        public static async Task<ApplicationUser> FindByEmailFromClaimsPrincipleWithAddress(this UserManager<ApplicationUser>
        input,ClaimsPrincipal user){
            var email = user?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)
            ?.Value;
            return await input.Users.Include(x=>x.Address).FirstOrDefaultAsync(x=>x.Email==email);
        }
          public static async Task<ApplicationUser> FindByEmailFromClaimsPrinciples(this UserManager<ApplicationUser>
        input,ClaimsPrincipal user){
            var email = user?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)
            ?.Value;
            return await input.Users.FirstOrDefaultAsync(x=>x.Email==email);
        }
    }
}