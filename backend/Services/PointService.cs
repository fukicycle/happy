using Happy.backend.Services.Interface;
using Happy.Shared.Dto.Response;
using Happy.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Happy.backend.Services
{
    public class PointService : IPointService
    {
        private readonly DB _db;
        private readonly ILogger<PointService> _logger;

        public PointService(DB db, ILogger<PointService> logger)
        {
            _db = db;
            _logger = logger;
        }

        public void AddPoint(string email, Guid goalPointGuid)
        {
            try
            {
                Member? member = _db.Members.Find(email);
                if (member == null)
                {
                    throw new Exception($"No such user: {email}");
                }
                PointHistory pointHistory = new PointHistory
                {
                    Date = DateTime.Now,
                    Email = email,
                    GaolPointGuid = goalPointGuid,
                    Guid = Guid.NewGuid()
                };
                _db.PointHistories.Add(pointHistory);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public UserPointResponseDto GetUserPointResponseDtoByEmail(string email)
        {
            try
            {
                Member? member = _db.Members.Find(email);
                if (member == null)
                {
                    throw new Exception($"No such user: {email}");
                }
                IList<PointHistory> pointHistories = _db.PointHistories.Include(pointHistory => pointHistory.GoalPoint).Where(pointHistory => pointHistory.Email == email).ToList();
                int yesterdayPoint = pointHistories.Where(pointHistory => pointHistory.Date == DateTime.Today.AddDays(-1)).Sum(pointHistory => pointHistory.GoalPoint.Point);
                int totalPoint = pointHistories.Sum(pointHistory => pointHistory.GoalPoint.Point);
                return new UserPointResponseDto(yesterdayPoint, totalPoint);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
