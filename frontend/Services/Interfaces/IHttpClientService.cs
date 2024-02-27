namespace frontend.Services.Interfaces
{
    public interface IHttpClientService
    {
        Task<HttpResponseResult<T>> SendAsync<T, T1>(HttpMethod method, string uri, T1? requestBody = default);
    }
}
