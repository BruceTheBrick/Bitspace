using System.Diagnostics;
using Bitspace.Core;
using Firebase.RemoteConfig;

namespace Bitspace.Platforms.iOS.Services;

public class RemoteConfigService : IRemoteConfigService
{
    public RemoteConfigService()
    {
        RemoteConfig.SharedInstance.ConfigSettings = GetFirebaseSettings();
    }

    public bool IsEnabled(string featureName)
    {
        try
        {
            return RemoteConfig.SharedInstance.GetConfigValue(featureName).BoolValue;
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

    public async Task FetchAndActivate()
    {
        try
        {
            await RemoteConfig.SharedInstance.FetchAsync(TimeoutConstants.REMOTECONFIG_MIN_FETCH_INTERVAL);
            await RemoteConfig.SharedInstance.ActivateAsync();
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
        }
    }

    private RemoteConfigSettings GetFirebaseSettings()
    {
        var settings = new RemoteConfigSettings();
        return settings;
    }
}