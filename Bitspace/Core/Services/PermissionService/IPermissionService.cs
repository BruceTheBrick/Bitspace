namespace Bitspace.Core;

public interface IPermissionService
{
    public Task<bool> RequestPermission(DevicePermissions permission);
}