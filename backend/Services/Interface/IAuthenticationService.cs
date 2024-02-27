using System.Security.Claims;

namespace backend.Services.Interface
{
    public interface IAuthenticationService
    {
        bool Authentication(string email);

        string GenerateAccessToken(string email);

        string GetEmailFromClaims(IEnumerable<Claim> claims);
    }
}
