namespace Happy.frontend.Pages
{
    public partial class AddGoal
    {
        private DateTime? _periodStartDate = null;
        private DateTime? _periodEndDate = null;

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
    }
}
