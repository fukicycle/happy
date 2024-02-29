using Happy.frontend.Services.Interfaces;
using Newtonsoft.Json;
using Happy.Shared;

namespace Happy.frontend.Services
{
    public class HttpClientService : IHttpClientService
    {
        private static string _token = string.Empty;
        private readonly HttpClient _httpClient;
        private readonly ILogger<HttpClientService> _logger;
        public HttpClientService(IHttpClientFactory httpClientFactory, ILogger<HttpClientService> logger)
        {
            _httpClient = httpClientFactory.CreateClient(ApplicationSettings.Mode.ToString());
            _logger = logger;
        }

        public async Task<HttpResponseResult> SendAsync(HttpMethod method, string uri, string? json = default)
        {
            try
            {
                if (_token != string.Empty)
                {
                    _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);
                }
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
                    return new HttpResponseResult(string.Empty, System.Net.HttpStatusCode.Unauthorized, "認証に失敗またはユーザが登録されていません。");
                }
                if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return new HttpResponseResult(string.Empty, System.Net.HttpStatusCode.NotFound, responseContent);
                }
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    return new HttpResponseResult(responseContent, System.Net.HttpStatusCode.OK);
                }
                throw new Exception(responseContent);
            }
            catch (Exception ex)
            {
                return new HttpResponseResult(string.Empty, System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public void SetAuthorizationToken(string? token)
        {
            if (token == null) throw new ArgumentNullException("Token is missing.");
            _logger.LogInformation(token);
            _token = token;
        }
    }
}
