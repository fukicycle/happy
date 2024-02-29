using Happy.backend.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Happy.Shared.Dto.Request;

namespace backend.Controllers
{
    [Route("/api/v1/points")]
    public class PointController : ControllerBase
    {
        private readonly IPointService _pointService;
        public PointController(IPointService pointService)
        {
            _pointService = pointService;
        }

        [HttpPost]
        public IActionResult PostPoint([FromBody] GainPointRequestDto gainPointRequestDto)
        {
            try
            {
                _pointService.AddPoint(gainPointRequestDto.Email, gainPointRequestDto.Point);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
