using Microsoft.AspNetCore.Components;

namespace Happy.frontend.Components
{
    public partial class CalendarCell
    {
        [Parameter]
        public DateTime DateTime { get; set; }
        [Parameter]
        public EventCallback<DateTime> CellOnClick { get; set; }

        private int? _day = null;

        protected override void OnInitialized()
        {
            _day = DateTime.Day;
        }

        private async Task CellOnClicked()
        {
            await CellOnClick.InvokeAsync(DateTime);
        }
    }
}
