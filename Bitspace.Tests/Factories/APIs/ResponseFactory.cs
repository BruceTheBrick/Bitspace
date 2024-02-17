using System.Net;
using Bitspace.Tests.Extensions;

namespace Bitspace.Tests.Factories;

public class ResponseFactory
{
    public static Response<T> GetSuccessfulResponse<T>(T data) where T : class
    {
        var faker = new Faker();
        return new Response<T>(data, HttpStatusCode.OK, faker.Internet.RandomHttpMethod(), true);
    }

    public static Response<T> GetUnsuccessfulResponse<T>(T data) where T : class
    {
        var faker = new Faker();
        return new Response<T>(data, HttpStatusCode.BadRequest, faker.Internet.RandomHttpMethod(), false, new Faker().Hacker.Phrase());
    }
}