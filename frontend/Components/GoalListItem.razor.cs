using Happy.frontend.Pages;
using Happy.Shared.Dto.Request;
using Happy.Shared.Dto.Response;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace Happy.frontend.Components
{
    public partial class GoalListItem : PageBase
    {
        [Parameter]
        public GoalPointResponseDto GoalPointResponseDto
        {
            get => _goalPointResponseDto;
            set
            {
                if (_goalPointResponseDto != value)
                {
                    _goalPointResponseDto = value;
                    GoalResponseDtoValueChanged();
                }
            }
        }

        private GoalPointResponseDto _goalPointResponseDto = null!;

        [Parameter]
        public bool IsDone { get; set; } = false;

        private string _displayText = string.Empty;
        private int _point = 0;

        private void GoalResponseDtoValueChanged()
        {
            if (_goalPointResponseDto == null) throw new ArgumentNullException(nameof(GoalPointResponseDto));
            _displayText = $"{_goalPointResponseDto.Content}({_goalPointResponseDto.Point}pt)";
            _point = _goalPointResponseDto.Point;
        }

        private async Task ClearButtonOnClick()
        {
            try
            {
                StateContainer.SetLoadingState(true);
                GainPointRequestDto gainPointRequestDto = new GainPointRequestDto(_point);
                string json = JsonConvert.SerializeObject(gainPointRequestDto);
                HttpResponseResult<string> response = await HttpClientService.SendAsync<string>(HttpMethod.Post, "/api/v1/points", json);
                if (response.StatusCode != System.Net.HttpStatusCode.OK) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                StateContainer.SetMessage(ex.Message);
            }
            finally
            {
                StateContainer.SetLoadingState(false);
            }
        }
    }
}
