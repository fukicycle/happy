using Happy.Shared.Dto.Response;

namespace Happy.backend.Services.Interface
{
    public interface IGoalService
    {
        GoalResponseDto? GetGoalResponseDtoByEmail(string email);
        IList<GoalPointResponseDto> GetGoalPointResponseDtosByGoalGuid(Guid guid);
    }
}
