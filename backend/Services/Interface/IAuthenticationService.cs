using System.Security.Claims;

namespace Happy.backend.Services.Interface
{
    public interface IAuthenticationService
    {
        bool Authentication(string email);

        string GenerateAccessToken(string email);

        string GetEmailFromClaims(IEnumerable<Claim> claims);
    }
}
