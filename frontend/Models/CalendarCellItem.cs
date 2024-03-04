namespace Happy.frontend.Models
{
    public sealed class CalendarCellItem
    {
        public CalendarCellItem(int year, int month, DateTime dateTime)
        {
            DateTime = dateTime;
            _year = year;
            _month = month;
            if (TargetDateIsThisMonth())
            {
                CssValue = GetDayOfWeekString();
            }
            else
            {
                CssValue = $"out-of-range {GetDayOfWeekString()}";
            }
        }
        public DateTime DateTime { get; }
        public string CssValue { get; private set; }

        private int _year;
        private int _month;

        private bool TargetDateIsThisMonth()
        {
            if (_year != DateTime.Year)
            {
                return false;
            }
            if (_month != DateTime.Month)
            {
                return false;
            }
            return true;
        }

        private string GetDayOfWeekString()
        {
            switch (DateTime.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    return "sun";
                case DayOfWeek.Monday:
                    return "mon";
                case DayOfWeek.Tuesday:
                    return "tue";
                case DayOfWeek.Wednesday:
                    return "wed";
                case DayOfWeek.Thursday:
                    return "thr";
                case DayOfWeek.Friday:
                    return "fri";
                case DayOfWeek.Saturday:
                    return "sat";
                default:
                    throw new NotSupportedException($"Not found enum:{nameof(DateTime.DayOfWeek)}");
            }
        }

    }
}
