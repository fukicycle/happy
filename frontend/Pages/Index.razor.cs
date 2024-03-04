using Happy.Shared.Dto.Response;
using Newtonsoft.Json;

namespace Happy.frontend.Pages
{
    public partial class Index : PageBase
    {
        private IEnumerable<GoalPointResponseDto> _goalPointResponseDtos = Enumerable.Empty<GoalPointResponseDto>();
        private UserPointResponseDto? _userPointResponseDto = null;
        protected override async Task OnInitializedAsync()
        {
            try
            {
                StateContainer.SetLoadingState(true);
                HttpResponseResult goalResponse = await HttpClientService.SendAsync(HttpMethod.Get, "/api/v1/goals");
                if (goalResponse.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    StateContainer.SetMessage(goalResponse.Message!);
                    return;
                }
                GoalResponseDto? goalResponseDto = JsonConvert.DeserializeObject<GoalResponseDto>(goalResponse.Json);
                if (goalResponseDto == null)
                {
                    throw new Exception($"Desirializeに失敗しました。{nameof(GoalResponseDto)}");
                }
                HttpResponseResult goalPointReponse =
                    await HttpClientService.SendAsync(
                        HttpMethod.Get,
                        $"/api/v1/goals/{goalResponseDto.Guid}/goal-points");
                if (goalPointReponse.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    StateContainer.SetMessage(goalPointReponse.Message!);
                    return;
                }
                IEnumerable<GoalPointResponseDto>? goalPointResponseDtos = JsonConvert.DeserializeObject<IEnumerable<GoalPointResponseDto>>(goalPointReponse.Json);
                if (goalPointResponseDtos == null)
                {
                    StateContainer.SetMessage($"Desirializeに失敗しました。{nameof(GoalResponseDto)}");
                    return;
                }
                _goalPointResponseDtos = goalPointResponseDtos;
                HttpResponseResult userPointResponse = await HttpClientService.SendAsync(HttpMethod.Get, "/api/v1/points");
                if (userPointResponse.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    StateContainer.SetMessage(goalPointReponse.Message!);
                    return;
                }
                UserPointResponseDto? userPointResponseDto = JsonConvert.DeserializeObject<UserPointResponseDto>(userPointResponse.Json);
                if (userPointResponseDto == null)
                {
                    StateContainer.SetMessage($"Desirializeに失敗しました。{nameof(UserPointResponseDto)}");
                    return;
                }
                _userPointResponseDto = userPointResponseDto;
            }
            finally
            {
                StateContainer.SetLoadingState(false);
            }
        }

        private void EditButtonOnClick()
        {
            NavigationManager.NavigateTo("add");
        }
    }
}
