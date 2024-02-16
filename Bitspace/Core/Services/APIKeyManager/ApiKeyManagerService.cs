namespace Bitspace.Core;

public class ApiKeyManagerService : IApiKeyManagerService
{
    private readonly IRemoteConfigService _remoteConfigService;

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
        return !string.IsNullOrWhiteSpace(_remoteConfigService.GetValue(api.ToString()));
    }
}