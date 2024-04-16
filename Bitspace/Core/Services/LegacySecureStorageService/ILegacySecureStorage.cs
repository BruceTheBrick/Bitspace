namespace Bitespace.Core;

public interface ILegacySecureStorage
{
    public Task<string> GetAsync(string key);
    public bool Remove(string key);
    public void RemoveAll();
}

public class LegacySecureStorage : ILegacySecureStorage
{
    public Task<string> GetAsync(string key)
    {
        return LegacySecureStorageImpl.GetAsync(key);
    }

    public bool Remove(string key)
    {
        return LegacySecureStorageImpl.Remove(key);
    }

    public void RemoveAll()
    {
        LegacySecureStorageImpl.RemoveAll();
    }
}