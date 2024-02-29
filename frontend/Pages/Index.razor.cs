using Shared;
using Shared.Dto.Response;

namespace frontend.Pages
{
    public partial class Index : PageBase
    {
        private GoalResponseDto goalResponseDto { get; set; } = null!;
        protected override async Task OnInitializedAsync()
        {
            StateContainer.SetLoadingState(true);
            HttpResponseResult<GoalResponseDto> response = await HttpClientService.SendAsync<GoalResponseDto>(HttpMethod.Get, "/api/v1/goals");
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                StateContainer.SetMessage(response.Message!);
            }
            StateContainer.SetLoadingState(false);
        }
    }
}
