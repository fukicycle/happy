using Happy.frontend.Models;
using Happy.frontend.Services.Interfaces;
using Happy.Shared;
using Happy.Shared.Dto.Response;
using Newtonsoft.Json;

namespace Happy.frontend.Services
{
    public sealed class CalendarService : ICalendarService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly ILogger<CalendarService> _logger;
        public CalendarService(IHttpClientService httpClientService, ILogger<CalendarService> logger)
        {
            _httpClientService = httpClientService;
            _logger = logger;

        }
        public async Task<IEnumerable<CalendarCellItem>> GetCalendarCellItemsAsync(int year, int month)
        {
            IList<string> dayOfWeekStrings = typeof(DayOfWeek).GetEnumNames().ToList();

            DateTime firstDate = DateTime.Parse($"{year:0000}-{month:00}-01");
            int firstDateOffsetValue = dayOfWeekStrings.IndexOf(firstDate.DayOfWeek.ToString());
            DateTime startDate = firstDate.AddDays(-firstDateOffsetValue);

            int dayCount = DateTime.DaysInMonth(year, month);
            DateTime lastDate = DateTime.Parse($"{year:0000}-{month:00}-{dayCount:00}");
            int lastDateOffsetValue = dayOfWeekStrings.IndexOf(lastDate.DayOfWeek.ToString());
            DateTime endDate = lastDate.AddDays(6 - lastDateOffsetValue);

            //TODO DBから値の取得を実施
            //IEnumerable<PointHistoryResponseDto> pointHistoryResponseDtos = await GetPointHistoriesAsync(year, month);
            await Task.Delay(1000);
            IList<CalendarCellItem> calendarCellItems = new List<CalendarCellItem>();
            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                CalendarCellItem calendarCellItem = new CalendarCellItem(year, month, date);
                calendarCellItems.Add(calendarCellItem);
            }
            return calendarCellItems;
        }

        private async Task<IEnumerable<PointHistoryResponseDto>> GetPointHistoriesAsync(int year, int month)
        {
            HttpResponseResult pointHistoriesResult = await _httpClientService.SendAsync(HttpMethod.Get, $"/api/v1/point-histories/{year}/{month}");
            if (pointHistoriesResult.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception(pointHistoriesResult.Message);
            }
            IEnumerable<PointHistoryResponseDto>? pointHistoryResponseDtos = JsonConvert.DeserializeObject<IEnumerable<PointHistoryResponseDto>>(pointHistoriesResult.Json);
            if (pointHistoryResponseDtos == null)
            {
                throw new Exception($"Desirializeに失敗しました。{nameof(IEnumerable<PointHistoryResponseDto>)}");
            }
            return pointHistoryResponseDtos;
        }
    }
}
