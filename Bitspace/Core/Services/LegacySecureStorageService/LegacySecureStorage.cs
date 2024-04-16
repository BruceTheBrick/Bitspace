#nullable enable

#if ANDROID
using Bitspace.Platforms.Droid.Services;

#elif IOS
using Bitspace.Platforms.iOS.Services;
#endif

#if ANDROID || IOS

namespace Bitespace.Core;

public static class LegacySecureStorageImpl
{
    private static readonly string Alias = $"{AppInfo.PackageName}.xamarinessentials";

    public static Task<string> GetAsync(string key)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(key);
        var result = string.Empty;

#if ANDROID
        var locker = new object();
        var encVal = Preferences.Get(key, null, Alias);

        if (string.IsNullOrEmpty(encVal))
        {
            return Task.FromResult(result);
        }

        var encData = Convert.FromBase64String(encVal);
        lock (locker)
        {
            var keyStore = new AndroidKeyStore(Platform.AppContext, Alias, false);
            result = keyStore.Decrypt(encData);
        }
#elif IOS
        var keyChain = new KeyChain();
        result = keyChain.ValueForKey(key, Alias);
#endif
        return Task.FromResult(result);
    }

    public static bool Remove(string key)
    {
        var result = false;

#if ANDROID
        Preferences.Remove(key, Alias);
        result = true;
#elif IOS
        var keyChain = new KeyChain();
        result = keyChain.Remove(key, Alias);
#endif
        return result;
    }

    public static void RemoveAll()
    {
#if ANDROID
        Preferences.Clear(Alias);
#elif IOS
        var keyChain = new KeyChain();
        keyChain.RemoveAll(Alias);
#endif
    }
}
#endif