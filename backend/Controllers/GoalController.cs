using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("/api/v1/goals")]
    public class GoalController : ControllerBase
    {
        private readonly DB _db;
        public GoalController(DB db)
        {
            _db = db;
        }
    }
}
