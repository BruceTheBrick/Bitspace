using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace Bitspace.Services.DeviceInformation
{
    public class DeviceInformationService : IDeviceInformationService
    {
        public DeviceInformationService()
        {
            IsiOS = DeviceInfo.Platform == DevicePlatform.iOS;
            IsAndroid = DeviceInfo.Platform == DevicePlatform.Android;
        }

        public bool IsiOS { get; }

        public bool IsAndroid { get; }
    }
}
