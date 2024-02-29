using backend.Services.Interface;
using Shared.Models;

namespace backend.Services
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

        public void AddPoint(string email, int point)
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
                    Point = point,
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
    }
}
