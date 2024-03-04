using Happy.frontend.Models;

namespace Happy.frontend.Pages
{
    public partial class Calendar : PageBase
    {
        private IEnumerable<CalendarCellItem> _calendarCellItems = Enumerable.Empty<CalendarCellItem>();
        private DateTime _date = DateTime.Today;

        protected override async Task OnInitializedAsync()
        {
            await RefreshCalendar();
        }

        private async Task PrevButtonOnClick()
        {
            _date = _date.AddMonths(-1);
            await RefreshCalendar();
        }

        private async Task NextButtonOnClick()
        {
            _date = _date.AddMonths(1);
            await RefreshCalendar();
        }

        private async Task RefreshCalendar()
        {
            try
            {
                StateContainer.SetLoadingState(true);
                _calendarCellItems = Enumerable.Empty<CalendarCellItem>();
                _calendarCellItems = await CalendarService.GetCalendarCellItemsAsync(_date.Year, _date.Month);
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
