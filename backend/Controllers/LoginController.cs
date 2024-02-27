using backend.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("/api/v1/login")]
    public class LoginController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public LoginController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpPost]
        public IActionResult Login([FromBody] string email)
        {
            if (_authenticationService.Authentication(email))
            {
                string token = _authenticationService.GenerateAccessToken(email);
                return Ok(token);
            }
            return Unauthorized();
        }
    }
}
