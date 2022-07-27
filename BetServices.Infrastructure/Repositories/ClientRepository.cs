using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BetServices.Domain.Contracts;
using BetServices.Infrastructure.Base;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Client = BetServices.Domain.Entities.Client;

namespace BetServices.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private ISqlUnitOfWork _sqlUnitOfWork;

        public ClientRepository(ISqlUnitOfWork sqlUnitOfWork)
        {
            _sqlUnitOfWork = sqlUnitOfWork;
        }

        public Task<IEnumerable<Client>> FindAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Client> Find(long id)
        {
            var parameters = new { Id = id};
            const string query = "SELECT * FROM Bet_Services.Clients WHERE Id = @Id";
            return await _sqlUnitOfWork.ExecuteQuerySingle<Client>(query, parameters);
        }

        public Task<List<Client>> FindBy(Expression<Func<Client, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void SaveRange(IEnumerable<Client> entities)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Client entity)
        {
            var parameters = new DynamicParameters(entity);
            const string query = "UPDATE Bet_Services.Clients SET Names = @Names, Surnames = @Surnames, Gender = @Gender, " +
                                 "EntityState = @EntityState, Credit = @Credit, CreationDate = @CreationDate, " +
                                 "UpdateTime = @UpdateTime WHERE Id = @Id";
            await _sqlUnitOfWork.ExecuteCommandAsync(query, parameters);
        }

        public void UpdateRange(IEnumerable<Client> entities)
        {
            throw new NotImplementedException();
        }

        public async Task Insert(Client entity)
        {
            var parameters = new DynamicParameters(entity);
            const string query = "INSERT INTO Bet_Services.Clients (Id, Names, Surnames, Gender, " +
                                 "EntityState, Credit, CreationDate, UpdateTime) " +
                                 "VALUES (@Id, @Names, @Surnames, @Gender, " +
                                 "@EntityState, @Credit, @CreationDate, @UpdateTime)";
            await _sqlUnitOfWork.ExecuteCommandAsync(query, parameters);
        }
    }
}