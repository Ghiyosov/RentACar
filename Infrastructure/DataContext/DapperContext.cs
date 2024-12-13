using Npgsql;

namespace Infrastructure.DataContext;

public class DapperContext
{
    readonly string _connectionString="Host=localhost;Port=5432;Database=rentacar;User Id=postgres;Password=832111;";

    public NpgsqlConnection GetConnection()
    {
        return new NpgsqlConnection(_connectionString);
    }
}