using Bookify.Application.Abstractions.Persistence;
using Npgsql;
using System.Data;

namespace Bookify.Infrastructure.Persistence;

internal sealed class SqlConnectionFactory(string connectionString)
    : ISqlConnectionFactory
{
    private readonly string _connectionString = connectionString;

    public IDbConnection CreateConnection()
    {
        var connection = new NpgsqlConnection(_connectionString);
        connection.Open();

        return connection;
    }
}
