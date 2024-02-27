using backend.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Shared.Dto.Request;
using Shared.Dto.Response;

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
        public IActionResult Login([FromBody] LoginRequestDto loginRequestDto)
        {
            if (_authenticationService.Authentication(loginRequestDto.Email))
            {
                string token = _authenticationService.GenerateAccessToken(loginRequestDto.Email);
                return Ok(new LoginResponseDto(token));
            }
            return Unauthorized();
        }
    }
}
