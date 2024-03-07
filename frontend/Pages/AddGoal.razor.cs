using Happy.frontend.Models;

namespace Happy.frontend.Pages
{
    public partial class AddGoal : PageBase
    {
        private DateTime? _periodStartDate = null;
        private DateTime? _periodEndDate = null;
        private IList<GoalPointItem> _goalPointItems = new List<GoalPointItem>();

        protected override void OnInitialized()
        {
            //TODO サービスへの切り出し(?)
            int idx = typeof(DayOfWeek).GetEnumNames().ToList().IndexOf(DateTime.Today.DayOfWeek.ToString());
            _periodStartDate = DateTime.Today.AddDays(-idx);
            _periodEndDate = _periodStartDate.Value.AddDays(6);
        }

        private string GetDisplayTextFromDateTime(DateTime? date)
        {
            if (date == null)
            {
                throw new ArgumentNullException($"Parameter is null: {nameof(date)}");
            }
            return date.Value.ToString("MM/dd(ddd)");
        }

        private void CancelButtonOnClick()
        {
            NavigationManager.NavigateTo("home");
        }

        private void AddRowButtonOnClick()
        {
            if (_goalPointItems.Count >= 6)
            {
                return;
            }
            _goalPointItems.Add(new GoalPointItem());
        }
    }
}
