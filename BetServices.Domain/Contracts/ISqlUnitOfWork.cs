using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;

namespace BetServices.Domain.Contracts
{
    public interface ISqlUnitOfWork
    {
        public Task<List<T>> ExecuteQuery<T>(string query, object parameters = null);
        public Task<T> ExecuteQuerySingle<T>(string query, object parameters);
        public Task<int> ExecuteCommandAsync(string command, DynamicParameters parameters = null);
    }
}