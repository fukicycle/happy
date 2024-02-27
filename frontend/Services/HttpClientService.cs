using frontend.Services.Interfaces;
using Newtonsoft.Json;
using Shared;

namespace frontend.Services
{
    public class HttpClientService : IHttpClientService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<HttpClientService> _logger;
        public HttpClientService(IHttpClientFactory httpClientFactory, ILogger<HttpClientService> logger)
        {
            _httpClient = httpClientFactory.CreateClient(ApplicationSettings.Mode.ToString());
            _logger = logger;
        }

        public async Task<HttpResponseResult<T>> SendAsync<T>(HttpMethod method, string uri, string? json = default)
        {
            try
            {
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(method, uri);
                if (json != null)
                {
                    StringContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                    httpRequestMessage.Content = content;
                }
                HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage);
                string responseContent = await httpResponseMessage.Content.ReadAsStringAsync();
                if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    return new HttpResponseResult<T>(default!, System.Net.HttpStatusCode.Unauthorized, responseContent);
                }
                if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return new HttpResponseResult<T>(default!, System.Net.HttpStatusCode.NotFound, responseContent);
                }
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    T? deserializedObject = JsonConvert.DeserializeObject<T>(responseContent) ?? throw new Exception($"Desirialized failed for class:{nameof(T)}");
                    return new HttpResponseResult<T>(deserializedObject, System.Net.HttpStatusCode.OK);
                }
                throw new Exception(responseContent);
            }
            catch (Exception ex)
            {
                return new HttpResponseResult<T>(default!, System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
