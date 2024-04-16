using System.Net.Http.Json;
using Bitspace.Tests.Extensions;

namespace Bitspace.Tests.Factories;

public static class HttpResponseMessageFactory
{
    public static HttpResponseMessage GetModel()
    {
        return GetModels(1).First();
    }
    
    public static List<HttpResponseMessage> GetModels(int count = 5)
    {
        return new Faker<HttpResponseMessage>()
            .RuleFor(x => x.Version, f => f.System.Version())
            .RuleFor(x => x.StatusCode, f => f.Internet.RandomHttpStatusCode())
            .RuleFor(x => x.ReasonPhrase, f => f.Hacker.Phrase())
            .Generate(count);
    }
}