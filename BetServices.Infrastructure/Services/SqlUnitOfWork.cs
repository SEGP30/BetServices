using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using BetServices.Domain.Contracts;
using Dapper;

namespace BetServices.Infrastructure.Services
{
    public class SqlUnitOfWork : ISqlUnitOfWork
    {
        private readonly DbConnection _sqlConnection;

        public SqlUnitOfWork(DbConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }
        
        public async Task<List<T>> ExecuteQuery<T>(string query, object parameters)
        {
            return (await _sqlConnection.QueryAsync<T>(query, parameters)).AsList();                        
        }

        public async Task<T> ExecuteQuerySingle<T>(string query, object parameters)
        {
            return await _sqlConnection.QuerySingleOrDefaultAsync<T>(query, parameters);                        
        }
        
        public async Task<int> ExecuteCommandAsync(string command, DynamicParameters parameters = null)
        {
            return await _sqlConnection.ExecuteAsync(command, parameters);
        }

    }
}