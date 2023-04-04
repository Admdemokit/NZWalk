using Microsoft.AspNetCore.Identity;

namespace NZWalks.API.Services.Interfaces.ITokens
{
    public interface ITokenRepositories
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
