using Microsoft.AspNetCore.Identity;

namespace Challenge.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
