using System;
using System.IO;
using SQLite;

namespace Bitspace.Services.DatabaseService;

public class DatabaseService : IDatabaseService
{
    private readonly SQLiteConnection _connection;
    public DatabaseService()
    {
        var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "bitspace.db3");
        _connection = new SQLiteConnection(path);
    }

    public int Insert<T>(T obj)
    {
        return _connection.Insert(obj);
    }

    public T Get<T>(int id) where T : new()
    {
        return _connection.Get<T>(id);
    }

    public bool Delete<T>(T obj)
    {
        return _connection.Delete(obj) > 0;
    }
}