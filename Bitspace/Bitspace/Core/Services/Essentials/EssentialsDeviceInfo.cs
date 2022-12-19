using Xamarin.Essentials;

namespace Bitspace.Core
{
    public class EssentialsDeviceInfo : IEssentialsDeviceInfo
    {
        public bool IsIos => DeviceInfo.Platform == DevicePlatform.iOS;
    }
}