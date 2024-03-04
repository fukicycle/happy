using Happy.frontend.Models;

namespace Happy.frontend.Services.Interfaces
{
    public interface ICalendarService
    {
        Task<IEnumerable<CalendarCellItem>> GetCalendarCellItemsAsync(int year, int month);
    }
}
