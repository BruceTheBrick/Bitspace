using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace Bitspace.APIs;

[ExcludeFromCodeCoverage]
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

    public Response(T data, HttpStatusCode statusCode, string method, bool isSuccess, string errorMessage = "")
    {
        Data = data;
        StatusCode = statusCode;
        Method = StringToMethod(method);
        IsSuccess = isSuccess;
        ErrorMessage = errorMessage;
    }

    public bool IsSuccess { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public HttpMethod Method { get; set; }
    public T Data { get; set; }
    public string ErrorMessage { get; set; }

    private HttpMethod StringToMethod(string methodString)
    {
        return methodString switch
        {
            "GET" => HttpMethod.Get,
            "POST" => HttpMethod.Post,
            "PUT" => HttpMethod.Put,
            "HEAD" => HttpMethod.Head,
            "DELETE" => HttpMethod.Delete,
            "PATCH" => HttpMethod.Patch,
            "OPTIONS" => HttpMethod.Options,
            _ => null
        };
    }
}