namespace Happy.frontend.Services.Interfaces
{
    public interface IHttpClientService
    {
        Task<HttpResponseResult<T>> SendAsync<T>(HttpMethod method, string uri, string? json = null);
    }
}
