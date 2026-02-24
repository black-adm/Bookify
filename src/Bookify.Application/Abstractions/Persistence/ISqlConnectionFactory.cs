using System.Data;

namespace Bookify.Application.Abstractions.Persistence;

public interface ISqlConnectionFactory
{
    IDbConnection CreateConnection();
}
