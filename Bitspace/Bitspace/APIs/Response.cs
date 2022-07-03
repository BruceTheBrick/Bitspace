namespace Bitspace.APIs;

public class Response<T> where T : class
{
    public enum HTTPMethod
    {
        GET,
        POST,
        UPDATE,
        PATCH,
        DELETE
    }

    public int StatusCode { get; set; }
    public HTTPMethod Method { get; set; }
    public T Data { get; set; }
}