using Happy.backend.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Happy.Shared;

namespace Happy.backend.Controllers
{
    [Authorize]
    [Route("/api/v1/goals")]
    public class GoalController : ControllerBase
    {
        private readonly IGoalService _goalService;
        private readonly IAuthenticationService _authenticationService;
        public GoalController(IGoalService goalService, IAuthenticationService authenticationService)
        {
            _goalService = goalService;
            _authenticationService = authenticationService;
        }

        [HttpGet]
        public IActionResult GetGoal()
        {
            string email = _authenticationService.GetEmailFromClaims(HttpContext.User.Claims);
            try
            {
                return Ok(_goalService.GetGoalResponseDtoByEmail(email));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{guid}/goal-points")]
        public IActionResult GetGoalPoints(Guid guid)
        {
            try
            {
                return Ok(_goalService.GetGoalPointResponseDtosByGoalGuid(guid));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
