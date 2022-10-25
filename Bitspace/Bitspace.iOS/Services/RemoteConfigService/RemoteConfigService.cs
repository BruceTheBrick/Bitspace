using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Bitspace.Core;
using Bitspace.Services;
using Firebase.RemoteConfig;

namespace Bitspace.iOS.Services
{
    public class RemoteConfigService : IRemoteConfigService
    {
        private readonly ITimeoutService _timeoutService;
        public RemoteConfigService(ITimeoutService timeoutService)
        {
            _timeoutService = timeoutService;
            _timeoutService.ExpiryMinutes = 5;
            RemoteConfig.SharedInstance.ConfigSettings = GetFirebaseSettings();
            RemoteConfig.SharedInstance.Init();
        }

        public async Task Initialize()
        {
            await RemoteConfig.SharedInstance.FetchAndActivateAsync();
        }

        public bool IsEnabled(string featureName)
        {
            try
            {
                if (_timeoutService.IsExpired())
                {
                    _timeoutService.Update();
                }

                return  RemoteConfig.SharedInstance.GetConfigValue(featureName).BoolValue;;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }

        public string GetValue(string featureName)
        {
            return RemoteConfig.SharedInstance.GetConfigValue(featureName).StringValue;
        }

        public Task FetchAndActivate()
        {
            return RemoteConfig.SharedInstance.FetchAndActivateAsync();
        }

        private RemoteConfigSettings GetFirebaseSettings()
        {
            var settings = new RemoteConfigSettings();
            settings.FetchTimeout = TimeoutConstants.REMOTECONFIG_TIMEOUT;
            settings.MinimumFetchInterval = TimeoutConstants.REMOTECONFIG_MIN_FETCH_INTERVAL;
            return settings;
        }
    }
}