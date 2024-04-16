namespace Bitspace.Core;

public class ApiKeyManagerService : IApiKeyManagerService
{
    private readonly IRemoteConfigService _remoteConfigService;

    public ApiKeyManagerService(IRemoteConfigService remoteConfigService)
    {
        _remoteConfigService = remoteConfigService;
    }

    public string GetKey(ApiEndpoints api)
    {
        return _remoteConfigService.GetValue($"{api}");
    }

    public bool HasKey(ApiEndpoints api)
    {
        return !string.IsNullOrWhiteSpace(_remoteConfigService.GetValue(api.ToString()));
    }
}