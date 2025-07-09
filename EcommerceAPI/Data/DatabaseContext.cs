using Microsoft.Data.Sqlite;

namespace EcommerceAPI.Data;

public class DatabaseContext
{
    private readonly string _connectionString;

    public DatabaseContext(string databasePath)
    {
        _connectionString = $"Data Source={databasePath}";
    }

    public SqliteConnection GetConnection()
    {
        return new SqliteConnection(_connectionString);
    }
}