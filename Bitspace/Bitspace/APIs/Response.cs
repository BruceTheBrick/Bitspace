using System.Net;

namespace Bitspace.APIs;

public class Response<T> where T : class
{
    public bool IsSuccess { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public BaseAPI.HTTPMethod Method { get; set; }
    public T Data { get; set; }
    public string ErrorMessage { get; set; }
}