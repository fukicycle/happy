namespace Happy.frontend.Services.Interfaces
{
    public interface IHttpClientService
    {
        Task<HttpResponseResult> SendAsync(HttpMethod method, string uri, string? json = null);
    }
}
