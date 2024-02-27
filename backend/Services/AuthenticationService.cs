using backend.Services.Interface;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace backend.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ILogger<AuthenticationService> _logger;
        private readonly IConfiguration _configuration;

        public AuthenticationService(ILogger<AuthenticationService> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        public bool Authentication(string email)
        {
            //demo
            return true;
        }

        public string GenerateAccessToken(string email)
        {
            string securityKey = _configuration["JWT:Key"];
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            IEnumerable<Claim> claims = new List<Claim> { new Claim("EMAIL", email) };
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "jwt",
                audience: "jwt",
                expires: DateTime.Now.AddSeconds(60), //demo
                signingCredentials: creds,
                claims: claims
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GetEmailFromClaims(IEnumerable<Claim> claims)
        {
            string? email = claims.FirstOrDefault(a => a.Type.Equals("EMAIL"))?.Value;
            if (email is null) return string.Empty;
            return email;
        }
    }
}
