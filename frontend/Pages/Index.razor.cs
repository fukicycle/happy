using Happy.Shared.Dto.Response;

namespace Happy.frontend.Pages
{
    public partial class Index : PageBase
    {
        private IEnumerable<GoalPointResponseDto> _goalPointResponseDtos = Enumerable.Empty<GoalPointResponseDto>();
        protected override async Task OnInitializedAsync()
        {
            try
            {

                StateContainer.SetLoadingState(true);
                HttpResponseResult<GoalResponseDto> goalResponse = await HttpClientService.SendAsync<GoalResponseDto>(HttpMethod.Get, "/api/v1/goals");
                if (goalResponse.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    StateContainer.SetMessage(goalResponse.Message!);
                    return;
                }
                HttpResponseResult<IEnumerable<GoalPointResponseDto>> goalPointReponse =
                    await HttpClientService.SendAsync<IEnumerable<GoalPointResponseDto>>(
                        HttpMethod.Get,
                        $"/api/v1/goals/{goalResponse.Content.Guid}/goal-points");
                if (goalPointReponse.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    StateContainer.SetMessage(goalPointReponse.Message!);
                    return;
                }

            }
            finally
            {
                StateContainer.SetLoadingState(false);
            }
        }
    }
}
