using System.Threading.Tasks;

namespace Bitspace.Services.DevicePermissions;

public interface IDevicePermissionService
{
    public enum Permission
    {
        BATTERY,
        CAMERA,
        FLASHLIGHT,
        MAPS,
        MEDIA,
        MICROPHONE,
        PHONE,
        PHOTOS,
        REMINDERS,
        SENSORS,
        SMS,
        SPEECH,
        VIBRATE,
        BASE_PERMISSION,
        CALENDAR_READ,
        CALENDAR_WRITE,
        CONTACTS_READ,
        CONTACTS_WRITE,
        LAUNCH_APP,
        LOCATION_ALWAYS,
        NETWORK_STATE,
        STORAGE_READ,
        STORAGE_WRITE,
        BASE_PLATFORM_PERMISSION,
        LOCATION_IN_USE
    }

    public Task<bool> IsGranted(Permission permission);
}