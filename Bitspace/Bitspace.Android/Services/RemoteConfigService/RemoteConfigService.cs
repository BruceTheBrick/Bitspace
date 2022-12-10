using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Bitspace.Core;
using Firebase.RemoteConfig;

namespace Bitspace.Droid.Services
{
    public class RemoteConfigService : IRemoteConfigService
    {
        private readonly ITimeoutService _timeoutService;
        public RemoteConfigService(ITimeoutService timeoutService)
        {
            _timeoutService = timeoutService;
            _timeoutService.ExpiryMinutes = 5;
            FirebaseRemoteConfig.Instance.SetConfigSettingsAsync(GetFirebaseSettings());
        }

        public bool IsEnabled(string featureName)
        {
            try
            {
                if (_timeoutService.IsExpired())
                {
                    FirebaseRemoteConfig.Instance.FetchAndActivate();
                    _timeoutService.Update();
                }

                return FirebaseRemoteConfig.Instance.GetBoolean(featureName);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }

        public string GetValue(string featureName)
        {
            return FirebaseRemoteConfig.Instance.GetString(featureName);
        }

        public Task FetchAndActivate()
        {
            FirebaseRemoteConfig.Instance.FetchAndActivate();
            return Task.CompletedTask;
        }

        private FirebaseRemoteConfigSettings GetFirebaseSettings()
        {
            return new FirebaseRemoteConfigSettings.Builder()
                .SetMinimumFetchIntervalInSeconds(TimeoutConstants.REMOTECONFIG_MIN_FETCH_INTERVAL)
                .SetFetchTimeoutInSeconds(TimeoutConstants.REMOTECONFIG_TIMEOUT)
                .Build();
        }
    }
}