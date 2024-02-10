using Bitspace.Core;

namespace Bitspace.Platforms.Droid.Services;

public class RemoteConfigService : IRemoteConfigService
{
    public RemoteConfigService()
    {
        // FirebaseRemoteConfig.Instance.SetConfigSettingsAsync(GetFirebaseSettings());
    }

    public bool IsEnabled(string featureName)
    {
        return true;
        // FirebaseRemoteConfig.Instance.FetchAndActivate();
        // return FirebaseRemoteConfig.Instance.GetBoolean(featureName);
    }

    public string GetValue(string featureName)
    {
        return string.Empty;
        // return FirebaseRemoteConfig.Instance.GetString(featureName);
    }

    public Task FetchAndActivate()
    {
        // FirebaseRemoteConfig.Instance.FetchAndActivate();
        return Task.CompletedTask;
    }

    // private FirebaseRemoteConfigSettings GetFirebaseSettings()
    // {
    //     return new FirebaseRemoteConfigSettings.Builder()
    //         .SetMinimumFetchIntervalInSeconds(TimeoutConstants.REMOTECONFIG_MIN_FETCH_INTERVAL)
    //         .SetFetchTimeoutInSeconds(TimeoutConstants.REMOTECONFIG_TIMEOUT)
    //         .Build();
    // }
}