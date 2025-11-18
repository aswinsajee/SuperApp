using Microsoft.AspNetCore.Identity;

namespace SuperAppAPI.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
