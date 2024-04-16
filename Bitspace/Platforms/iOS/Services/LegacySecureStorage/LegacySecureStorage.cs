using Foundation;
using Security;

namespace Bitspace.Platforms.iOS.Services;

public class KeyChain
{
    private SecRecord ExistingRecordForKey(string key, string service)
    {
        return new SecRecord(SecKind.GenericPassword)
        {
            Account = key,
            Service = service,
        };
    }

    internal string ValueForKey(string key, string service)
    {
        using var record = ExistingRecordForKey(key, service);
        using var match = SecKeyChain.QueryAsRecord(record, out var resultCode);
        if (resultCode == SecStatusCode.Success)
        {
            return NSString.FromData(match.ValueData, NSStringEncoding.UTF8);
        }

        return null;
    }

    internal bool Remove(string key, string service)
    {
        using var record = ExistingRecordForKey(key, service);
        using var match = SecKeyChain.QueryAsRecord(record, out var resultCode);
        if (resultCode == SecStatusCode.Success)
        {
            RemoveRecord(record);
            return true;
        }

        return false;
    }

    internal void RemoveAll(string service)
    {
        using var query = new SecRecord(SecKind.GenericPassword);
        query.Service = service;
        SecKeyChain.Remove(query);
    }

    private void RemoveRecord(SecRecord record)
    {
        var result = SecKeyChain.Remove(record);
        if (result != SecStatusCode.Success && result != SecStatusCode.ItemNotFound)
        {
            throw new Exception($"Error removing record: {result}");
        }
    }
}