namespace Bitspace.Services;

public interface IDatabaseService
{
    int Insert<T>(T obj);
    T Get<T>(int id) where T : new();
    bool Delete<T>(T obj);
}