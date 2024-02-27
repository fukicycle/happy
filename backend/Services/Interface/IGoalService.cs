using Shared.Dto.Response;

namespace backend.Services.Interface
{
    public interface IGoalService
    {
        GoalResponseDto? GetGoalResponseDtoByEmail(string email);
        IList<GoalPointResponseDto> GetGoalPointResponseDtoListByGoalGuid(Guid guid);
    }
}
