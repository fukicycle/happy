using Shared;

namespace frontend.Pages
{
    public partial class Index
    {
        private readonly HttpClient _httpClient;
        public Index()
        {
            _httpClient = HttpClientFactory.CreateClient(ApplicationSettings.Mode.ToString());
        }
    }
}
