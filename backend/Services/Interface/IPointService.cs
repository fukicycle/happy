using Happy.Shared.Dto.Response;

namespace Happy.backend.Services.Interface
{
    public interface IPointService
    {
        void AddPoint(string email, Guid goalPointGuid);
        UserPointResponseDto GetUserPointResponseDtoByEmail(string email);
    }
}
