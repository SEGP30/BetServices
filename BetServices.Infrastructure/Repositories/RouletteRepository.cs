using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BetServices.Domain.Contracts;
using BetServices.Domain.Entities;
using BetServices.Infrastructure.Base;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

namespace BetServices.Infrastructure.Repositories
{
    public class RouletteRepository : IRouletteRepository
    {
        private ISqlUnitOfWork _sqlUnitOfWork;

        public RouletteRepository(ISqlUnitOfWork sqlUnitOfWork)
        {
            _sqlUnitOfWork = sqlUnitOfWork;
        }

        public async Task<IEnumerable<Roulette>> FindAll()
        {
            const string query = "SELECT * FROM Bet_Services.Roulettes";
            return await _sqlUnitOfWork.ExecuteQuery<Roulette>(query);
        }

        public async Task<Roulette> Find(long id)
        {
            var parameters = new { Id = id};
            const string query = "SELECT * FROM Bet_Services.Roulettes WHERE Id = @Id";
            return await _sqlUnitOfWork.ExecuteQuerySingle<Roulette>(query, parameters);
        }

        public Task<List<Roulette>> FindBy(Expression<Func<Roulette, bool>> predicate)
        {
            throw new NotImplementedException();

        }
        
        public async Task<Roulette> FindOpenRoulette(long id)
        {
            var parameters = new { Id = id};
            const string query = "SELECT * FROM Bet_Services.Roulettes WHERE Id = @Id AND State = 1";
            return await _sqlUnitOfWork.ExecuteQuerySingle<Roulette>(query, parameters);
        }
        
        public async Task<Roulette> FindUnnoperativeRoulette(long id)
        {
            var parameters = new { Id = id};
            const string query = "SELECT * FROM Bet_Services.Roulettes WHERE Id = @Id AND State != 1";
            return await _sqlUnitOfWork.ExecuteQuerySingle<Roulette>(query, parameters);
        }
        
        public void SaveRange(IEnumerable<Roulette> entities)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Roulette entity)
        {
            var parameters = new DynamicParameters(entity);
            const string query = "UPDATE Bet_Services.Roulettes SET State = @State, EntityState = @EntityState, " +
                                 "CreationDate = @CreationDate, UpdateTime = @UpdateTime WHERE Id = @Id";
            await _sqlUnitOfWork.ExecuteCommandAsync(query, parameters);
        }

        public void UpdateRange(IEnumerable<Roulette> entities)
        {
            throw new NotImplementedException();
        }

        public async Task Insert(Roulette entity)
        {
            var parameters = new DynamicParameters(entity);
            const string query = "INSERT INTO Bet_Services.Roulettes (Id, State, EntityState, CreationDate, UpdateTime) " +
                                 "VALUES (@Id, @State, @EntityState, @CreationDate, @UpdateTime)";
            await _sqlUnitOfWork.ExecuteCommandAsync(query, parameters);
        }
    }
}