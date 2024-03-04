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
        private Guid _goalPointGuid = Guid.Empty;

        private ConfirmationDialog _confirmationDialog { get; set; } = null!;

        private void GoalResponseDtoValueChanged()
        {
            if (_goalPointResponseDto == null) throw new ArgumentNullException(nameof(GoalPointResponseDto));
            _displayText = $"{_goalPointResponseDto.Content}({_goalPointResponseDto.Point}pt)";
            _goalPointGuid = _goalPointResponseDto.GoalPointGuid;
        }

        private async Task OkButtonOnClick()
        {
            try
            {
                StateContainer.SetLoadingState(true);
                GainPointRequestDto gainPointRequestDto = new GainPointRequestDto(_goalPointGuid);
                string json = JsonConvert.SerializeObject(gainPointRequestDto);
                HttpResponseResult response = await HttpClientService.SendAsync(HttpMethod.Post, "/api/v1/points", json);
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

        private void ClearButtonOnClick()
        {
            _confirmationDialog.Open();
        }
    }
}
