using Domain.IdentityEntities;

namespace Domain.Interfaces
{
    public interface ITokenService
    {
         string CreateToken(ApplicationUser appUser);
    }
}