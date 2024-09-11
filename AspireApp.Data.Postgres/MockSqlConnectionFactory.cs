using AspireApp.Common.Data;
using System.Data;

namespace AspireApp.Data.Postgres;

internal sealed class MockSqlConnectionFactory() : ISqlConnectionFactory
{

    public IDbConnection CreateConnection()
    {
        return new MockConnection();

    }
}

public sealed class MockConnection : IDbConnection
{
    public string ConnectionString { get; set; } = string.Empty;

    public int ConnectionTimeout => throw new NotImplementedException();

    public string Database => throw new NotImplementedException();

    public ConnectionState State => throw new NotImplementedException();

    public IDbTransaction BeginTransaction()
    {
        throw new NotImplementedException();
    }

    public IDbTransaction BeginTransaction(IsolationLevel il)
    {
        throw new NotImplementedException();
    }

    public void ChangeDatabase(string databaseName)
    {
        throw new NotImplementedException();
    }

    public void Close()
    {
    }

    public IDbCommand CreateCommand()
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
    }

    public void Open()
    {
    }
}