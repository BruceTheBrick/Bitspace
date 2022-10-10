using Bitspace.APIs;

namespace Bitspace.Services;

public class ApiKeyManagerService : IApiKeyManagerService
{
    private IRemoteConfigService _remoteConfigService;

    public ApiKeyManagerService(IRemoteConfigService remoteConfigService)
    {
        _remoteConfigService = remoteConfigService;
    }

    public string GetKey(API_Endpoints api)
    {
        return _remoteConfigService.GetValue(api.ToString());
    }

    public bool HasKey(API_Endpoints api)
    {
        return _remoteConfigService.Exists(api.ToString());
    }
}