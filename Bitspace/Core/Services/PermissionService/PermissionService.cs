using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Bitspace.Core;

[ExcludeFromCodeCoverage]
public class PermissionService : IPermissionService
{
    public async Task<bool> RequestPermission(DevicePermissions permission)
    {
        switch (permission)
        {
            case DevicePermissions.STORAGE:
            {
                return await RequestStoragePermissions();
            }

            case DevicePermissions.LOCATION:
            {
                return await RequestLocationPermissions();
            }

            default:
            {
                return false;
            }
        }
    }

    private async Task<bool> RequestLocationPermissions()
    {
        try
        {
            var result = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            return IsPermissionGranted(result);
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            return false;
        }
    }

    private async Task<bool> RequestStoragePermissions()
    {
        var readResult = await Permissions.RequestAsync<Permissions.StorageRead>();
        var writeResult = await Permissions.RequestAsync<Permissions.StorageWrite>();
        return IsPermissionGranted(readResult) && IsPermissionGranted(writeResult);
    }

    private bool IsPermissionGranted(PermissionStatus status)
    {
        var grantedOptions = new[] { PermissionStatus.Granted, PermissionStatus.Limited, PermissionStatus.Restricted };
        return grantedOptions.Contains(status);
    }
}