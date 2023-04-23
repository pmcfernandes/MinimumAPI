using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace APIBase;

public class SqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration configuration;

    public SqlDataAccess(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public async Task<IEnumerable<T>> Load<T, U>(string storedProcedure, U parameters, string connectionId = "Default")
    {
        using (IDbConnection conn = new SqlConnection(configuration.GetConnectionString(connectionId)))
        {
            return await conn.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }
    }

    public async Task Save<T>(string storedProcedure, T parameters, string connectionId = "Default")
    {
        using (IDbConnection conn = new SqlConnection(configuration.GetConnectionString(connectionId)))
        {
            await conn.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
