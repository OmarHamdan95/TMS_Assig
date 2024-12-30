using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
namespace TMS.Database.Repositories.Dapper;

public class DapperService :IDapperService
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public DapperService(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("Context");
    }

    public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null)
    {
        using var connection = new SqlConnection(_connectionString);
        return await connection.QueryAsync<T>(sql, param, commandType: CommandType.StoredProcedure);
    }

    public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null)
    {
        using var connection = new SqlConnection(_connectionString);
        return await connection.QueryFirstOrDefaultAsync<T>(sql, param, commandType: CommandType.StoredProcedure);
    }

    public async Task<int> ExecuteAsync(string sql, object param = null)
    {
        using var connection = new SqlConnection(_connectionString);
        return await connection.ExecuteAsync(sql, param, commandType: CommandType.StoredProcedure);
    }

    public async Task<T> QuerySingleAsync<T>(string sql, object param = null)
    {
        using var connection = new SqlConnection(_connectionString);
        return await connection.QuerySingleAsync<T>(sql, param, commandType: CommandType.StoredProcedure);
    }
}
