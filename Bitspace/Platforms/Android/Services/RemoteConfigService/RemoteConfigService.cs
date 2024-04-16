using Android.Gms.Extensions;
using Firebase.RemoteConfig;

namespace Bitspace.Platforms.Droid.Services;

public class RemoteConfigService : IRemoteConfigService
{
    public RemoteConfigService()
    {
        FirebaseRemoteConfig.Instance.SetConfigSettingsAsync(GetFirebaseSettings());
    }

    public bool IsEnabled(string featureName)
    {
        FirebaseRemoteConfig.Instance.FetchAndActivate();
        return FirebaseRemoteConfig.Instance.GetBoolean(featureName);
    }

    public string GetValue(string featureName)
    {
        return FirebaseRemoteConfig.Instance.GetString(featureName);
    }

    public Task FetchAndActivate()
    {
        return FirebaseRemoteConfig.Instance.FetchAndActivate().AsAsync();
    }

    private FirebaseRemoteConfigSettings GetFirebaseSettings()
    {
        return new FirebaseRemoteConfigSettings.Builder()
            .SetMinimumFetchIntervalInSeconds(TimeoutConstants.RemoteConfigMinimumFetchInterval)
            .SetFetchTimeoutInSeconds(TimeoutConstants.RemoteConfigTimeout)
            .Build();
    }
}