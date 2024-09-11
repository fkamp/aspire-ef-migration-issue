using System.Data;

namespace AspireApp.Common.Data;

public interface ISqlConnectionFactory
{
    IDbConnection CreateConnection();
}