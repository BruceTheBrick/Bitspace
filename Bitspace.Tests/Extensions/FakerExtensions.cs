using System.Net;
using Bogus.DataSets;

namespace Bitspace.Tests.Extensions;

public static class FakerExtensions
{
    public static HttpMethod RandomHttpMethod(this Internet _)
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

    public static HttpStatusCode RandomHttpStatusCode(this Internet _)
    {
        var faker = new Faker();
        return faker.PickRandom<HttpStatusCode>();
    }
}