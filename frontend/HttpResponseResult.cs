using System.Net;

namespace Happy.frontend
{
    public class HttpResponseResult<T>
    {
        public HttpResponseResult(T content, HttpStatusCode statusCode, string? message = null)
        {
            Content = content;
            StatusCode = statusCode;
            Message = message;
        }
        public T Content { get; }
        public HttpStatusCode StatusCode { get; }
        public string? Message { get; }
    }
}
