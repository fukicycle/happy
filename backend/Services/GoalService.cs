using Happy.backend.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Happy.Shared.Dto.Response;
using Happy.Shared.Models;

namespace Happy.backend.Services
{
    public class GoalService : IGoalService
    {
        private readonly DB _db;
        private readonly ILogger<GoalService> _logger;
        public GoalService(DB db, ILogger<GoalService> logger)
        {
            _db = db;
            _logger = logger;
        }

        public IList<GoalPointResponseDto> GetGoalPointResponseDtosByGoalGuid(Guid guid)
        {
            IList<GoalPointResponseDto> goalPointResponseDtoList = new List<GoalPointResponseDto>();
            try
            {
                Goal goal = _db.Goals.Include(a => a.GoalPoints).Single(goal => goal.Guid == guid);
                IEnumerable<GoalPoint> goalPointList = goal.GoalPoints;
                foreach (GoalPoint goalPoint in goalPointList)
                {
                    GoalPointResponseDto goalPointResponseDto = new GoalPointResponseDto(goalPoint.Guid, goalPoint.Content, goalPoint.Point);
                    goalPointResponseDtoList.Add(goalPointResponseDto);
                }
                _logger.LogInformation("Fetch completed for Goal points.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            return goalPointResponseDtoList;
        }

        public GoalResponseDto? GetGoalResponseDtoByEmail(string email)
        {
            try
            {
                Goal? goal = _db.Goals.Where(goal => goal.Email == email).OrderByDescending(goal => goal.Date).FirstOrDefault();
                if (goal == null) return null;
                GoalResponseDto goalResponseDto = new GoalResponseDto(goal.Guid, goal.Email, goal.TargetYear, goal.TargetMonth);
                return goalResponseDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
