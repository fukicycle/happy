using Happy.backend.Services.Interface;
using Microsoft.IdentityModel.Tokens;
using Happy.Shared;
using Happy.Shared.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Happy.backend.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ILogger<AuthenticationService> _logger;
        private readonly IConfiguration _configuration;
        private readonly DB _db;

        public AuthenticationService(ILogger<AuthenticationService> logger, IConfiguration configuration, DB db)
        {
            _logger = logger;
            _configuration = configuration;
            _db = db;
        }
        public bool Authentication(string email)
        {
            Member? member = _db.Members.Find(email);
            return member != null;
        }

        public string GenerateAccessToken(string email)
        {
            SymmetricSecurityKey key = new SymmetricSecurityKey(ApplicationSettings.JWT_KEY);
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            IEnumerable<Claim> claims = new List<Claim> { new Claim("EMAIL", email) };
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "sato-home.mydns.jp",
                audience: "fukicycle.github.io",
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddDays(30), //demo
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
