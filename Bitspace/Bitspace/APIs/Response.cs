using System.Net;
using System.Net.Http;

namespace Bitspace.APIs;

public class Response<T> where T : class
{
    public Response(T data, HttpStatusCode statusCode, HttpMethod method, bool isSuccess, string errorMessage = "")
    {
        Data = data;
        StatusCode = statusCode;
        Method = method;
        IsSuccess = isSuccess;
        ErrorMessage = errorMessage;
    }

    public bool IsSuccess { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public HttpMethod Method { get; set; }
    public T Data { get; set; }
    public string ErrorMessage { get; set; }
}