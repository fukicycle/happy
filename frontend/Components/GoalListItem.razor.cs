using Happy.Shared.Dto.Response;
using Microsoft.AspNetCore.Components;

namespace Happy.frontend.Components
{
    public partial class GoalListItem
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

        private void GoalResponseDtoValueChanged()
        {
            if (_goalPointResponseDto == null) throw new ArgumentNullException(nameof(GoalPointResponseDto));
            _displayText = $"{_goalPointResponseDto.Content}({_goalPointResponseDto.Point}pt)";
        }
    }
}
