namespace Bitspace.Core;

public interface IApiKeyManagerService
{
    public string GetKey(ApiEndpoints api);
    public bool HasKey(ApiEndpoints api);
}