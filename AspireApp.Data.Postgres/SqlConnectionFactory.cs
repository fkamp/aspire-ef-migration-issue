using AspireApp.Common.Data;
using Npgsql;
using System.Data;

namespace AspireApp.Data.Postgres;

internal sealed class SqlConnectionFactory(NpgsqlDataSource dataSource) : ISqlConnectionFactory
{
    private readonly NpgsqlDataSource _dataSource = dataSource;

    public IDbConnection CreateConnection()
    {
        var connection = _dataSource.OpenConnection();
        return connection;

    }
}