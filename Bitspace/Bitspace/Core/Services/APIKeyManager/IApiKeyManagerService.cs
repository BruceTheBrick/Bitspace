using Bitspace.APIs;

namespace Bitspace.Core
{
    public interface IApiKeyManagerService
    {
        public string GetKey(API_Endpoints api);
        public bool HasKey(API_Endpoints api);
    }
}