using System;
using System.Threading.Tasks;

namespace Bitspace.Services.CachingService;

public interface ICachingService
{
    void Add(string itemName, string value);
    Task<bool> Exists(string itemName);
    Task<string> Get(string itemName);
    bool Remove(string itemName);
    bool ClearAll();
}