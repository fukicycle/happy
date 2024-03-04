using Happy.backend.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Happy.Shared.Dto.Request;
using Microsoft.AspNetCore.Authorization;
using Happy.Shared.Dto.Response;

namespace backend.Controllers
{
    [Authorize]
    [Route("/api/v1/points")]
    public class PointController : ControllerBase
    {
        private readonly IPointService _pointService;
        private readonly IAuthenticationService _authenticationService;
        public PointController(IPointService pointService, IAuthenticationService authenticationService)
        {
            _pointService = pointService;
            _authenticationService = authenticationService;
        }

        [HttpPost]
        public IActionResult PostPoint([FromBody] GainPointRequestDto gainPointRequestDto)
        {
            try
            {
                string email = _authenticationService.GetEmailFromClaims(HttpContext.User.Claims);
                _pointService.AddPoint(email, gainPointRequestDto.GoalPointGuid);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetUserPoint()
        {
            try
            {
                string email = _authenticationService.GetEmailFromClaims(HttpContext.User.Claims);
                UserPointResponseDto userPointResponseDto = _pointService.GetUserPointResponseDtoByEmail(email);
                return Ok(userPointResponseDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
