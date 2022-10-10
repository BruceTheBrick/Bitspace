using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Bitspace.Services;

[ExcludeFromCodeCoverage]
public class PermissionService : IPermissionService
{
    public async Task<bool> RequestPermission(DevicePermissions permission)
    {
        return permission switch
        {
            DevicePermissions.LOCATION => await RequestLocationPermissions(),
            DevicePermissions.STORAGE => await RequestStoragePermissions(),
            _ => false
        };
    }

    private async Task<bool> RequestLocationPermissions()
    {
        try
        {
            var result = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            return result == PermissionStatus.Granted;
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
        return readResult == PermissionStatus.Granted && writeResult == PermissionStatus.Granted;
    }
}