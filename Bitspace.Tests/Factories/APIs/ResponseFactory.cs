using System.Net;

namespace Bitspace.Tests.Factories;

public class ResponseFactory
{
    public static Response<T> GetSuccessfulResponse<T>(T data) where T : class
    {

        return new Response<T>(data, HttpStatusCode.OK, GetMethod(), true);
    }

    public static Response<T> GetUnsuccessfulResponse<T>(T data) where T : class
    {
        return new Response<T>(data, HttpStatusCode.BadRequest, GetMethod(), false, new Faker().Hacker.Phrase());
    }

    private static HttpMethod GetMethod()
    {
        var faker = new Faker();
        return faker.PickRandomParam(
            HttpMethod.Delete, 
            HttpMethod.Get, 
            HttpMethod.Head, 
            HttpMethod.Options,
            HttpMethod.Patch, 
            HttpMethod.Post, 
            HttpMethod.Put, 
            HttpMethod.Trace);
    }
}