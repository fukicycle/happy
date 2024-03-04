using Happy.backend.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Happy.Shared.Dto.Request;
using Microsoft.AspNetCore.Authorization;

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
        public IActionResult GetYesterdayPoint()
        {
            try
            {
                string email = _authenticationService.GetEmailFromClaims(HttpContext.User.Claims);
                //TODO 前日のポイント合計を返す
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
