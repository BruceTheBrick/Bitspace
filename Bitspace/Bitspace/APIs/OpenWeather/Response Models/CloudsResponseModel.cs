using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Bitspace.APIs
{
    [ExcludeFromCodeCoverage]
    public class CloudsResponseModel
    {
        [JsonProperty("all")]
        public int All { get; set; }
    }
}
