using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Bitspace.Services;

public class CachingService : ICachingService
{
    public void Add(string itemName, string value)
    {
        SecureStorage.SetAsync(itemName, value);
    }

    public async Task<bool> Exists(string itemName)
    {
        return string.IsNullOrEmpty(await SecureStorage.GetAsync(itemName));
    }

    public async Task<string> Get(string itemName)
    {
        return await SecureStorage.GetAsync(itemName);
    }

    public bool Remove(string itemName)
    {
        try
        {
            SecureStorage.Remove(itemName);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool ClearAll()
    {
        try
        {
            SecureStorage.RemoveAll();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}