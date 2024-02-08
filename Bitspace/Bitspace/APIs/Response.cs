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
        switch (methodString)
        {
            case "GET":
                return HttpMethod.Get;
            case "POST":
                return HttpMethod.Post;
            case "PUT":
                return HttpMethod.Put;
            case "HEAD":
                return HttpMethod.Head;
            case "DELETE":
                return HttpMethod.Delete;
            case "PATCH":
                return HttpMethod.Patch;
            case "OPTIONS":
                return HttpMethod.Options;
        }

        return null;
    }
}