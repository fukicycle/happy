using backend.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace backend.Controllers
{
    [Route("/api/v1/goals")]
    public class GoalController : ControllerBase
    {
        private readonly IGoalService _goalService;
        public GoalController(IGoalService goalService)
        {
            _goalService = goalService;
        }

        [HttpGet("{email}")]
        public IActionResult GetGoal(string email)
        {
            try
            {
                return Ok(_goalService.GetGoalResponseDtoByEmail(email));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{guid}/goal-point-list")]
        public IActionResult GetGoalPointList(Guid guid)
        {
            try
            {
                return Ok(_goalService.GetGoalPointResponseDtoListByGoalGuid(guid));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
