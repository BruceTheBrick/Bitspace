using System.Net;
using System.Net.Http;

namespace Bitspace.APIs;

public class Response<T> where T : class
{
    public bool IsSuccess { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public HttpMethod Method { get; set; }
    public T Data { get; set; }
    public string ErrorMessage { get; set; }
}