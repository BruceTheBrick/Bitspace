using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Permission = Bitspace.Services.DevicePermissions.IDevicePermissionService.Permission;

namespace Bitspace.Services.DevicePermissions;

public class DevicePermissionsService : IDevicePermissionService
{
    

    public Task<bool> IsGranted(Permission permission)
    {
        var classType = Type.GetType(GetPermissiontByName(permission));
        // return await Permissions.CheckStatusAsync<>();
        return null;
    }
    
    private string GetPermissiontByName(Permission permission)
    {
        return permission switch
        {
            Permission.SMS => nameof(Permissions.Sms),
            Permission.BATTERY => nameof(Permissions.Battery),
            Permission.CAMERA => nameof(Permissions.Camera),
            Permission.FLASHLIGHT => nameof(Permissions.Flashlight),
            Permission.MAPS => nameof(Permissions.Maps),
            Permission.MEDIA => nameof(Permissions.Media),
            Permission.MICROPHONE => nameof(Permissions.Microphone),
            Permission.PHONE => nameof(Permissions.Phone),
            Permission.PHOTOS => nameof(Permissions.Photos),
            Permission.REMINDERS => nameof(Permissions.Reminders),
            Permission.SENSORS => nameof(Permissions.Sensors),
            Permission.SPEECH => nameof(Permissions.Speech),
            Permission.VIBRATE => nameof(Permissions.Vibrate),
            Permission.BASE_PERMISSION => nameof(Permissions.BasePermission),
            Permission.CALENDAR_READ => nameof(Permissions.CalendarRead),
            Permission.CALENDAR_WRITE => nameof(Permissions.CalendarWrite),
            Permission.CONTACTS_READ => nameof(Permissions.ContactsRead),
            Permission.CONTACTS_WRITE => nameof(Permissions.ContactsWrite),
            Permission.LAUNCH_APP => nameof(Permissions.LaunchApp),
            Permission.LOCATION_ALWAYS => nameof(Permissions.LocationAlways),
            Permission.NETWORK_STATE => nameof(Permissions.NetworkState),
            Permission.STORAGE_READ => nameof(Permissions.StorageRead),
            Permission.STORAGE_WRITE => nameof(Permissions.StorageWrite),
            Permission.BASE_PLATFORM_PERMISSION => nameof(Permissions.BasePlatformPermission),
            Permission.LOCATION_IN_USE => nameof(Permissions.LocationWhenInUse),
            _ => string.Empty
        };
    }
}