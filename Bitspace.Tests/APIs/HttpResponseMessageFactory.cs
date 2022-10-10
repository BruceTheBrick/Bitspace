using System.Net;
using Bogus;

namespace Bitspace.Tests.APIs;

public static class HttpResponseMessageFactory
{
    public static HttpResponseMessage GetModel()
    {
        return GetModels(1).First();
    }

    public static HttpResponseMessage[] GetModels(int count = 5)
    {
        return new Faker<HttpResponseMessage>()
            .RuleFor(x => x.RequestMessage, GetHttpRequestMessage)
            .RuleFor(x => x.IsSuccessStatusCode, (f, z) => z.StatusCode == HttpStatusCode.OK)
            .Generate(count).ToArray();
    }

    public static HttpRequestMessage GetHttpRequestMessage()
    {
        return new Faker<HttpRequestMessage>()
            .RuleFor(x => x.Method, f => f.PickRandomParam(
                HttpMethod.Delete,
                HttpMethod.Get,
                HttpMethod.Head,
                HttpMethod.Options,
                HttpMethod.Patch,
                HttpMethod.Post,
                HttpMethod.Put,
                HttpMethod.Trace)).Generate();
    }
}