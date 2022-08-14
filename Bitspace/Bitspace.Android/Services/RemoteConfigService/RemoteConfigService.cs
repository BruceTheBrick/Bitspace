using System;
using System.Diagnostics;
using Bitspace.Services;
using Firebase.RemoteConfig;

namespace Bitspace.Droid.Services.RemoteConfigService;

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

    public void Update()
    {
        FirebaseRemoteConfig.Instance.FetchAndActivate();
    }

    public bool Exists(string featureName)
    {
        return !string.IsNullOrWhiteSpace(FirebaseRemoteConfig.Instance.GetString(featureName));
    }

    private FirebaseRemoteConfigSettings GetFirebaseSettings()
    {
        return new FirebaseRemoteConfigSettings.Builder()
            .SetMinimumFetchIntervalInSeconds(10)
            .Build();
    }
}