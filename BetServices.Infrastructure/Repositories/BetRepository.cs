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
    public class BetRepository : IBetRepository
    {
        private ISqlUnitOfWork _sqlUnitOfWork; 
        public BetRepository(ISqlUnitOfWork sqlUnitOfWork)
        {
            _sqlUnitOfWork = sqlUnitOfWork;
        }
        public Task<IEnumerable<Bet>> FindAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Bet> Find(long id)
        {
            var parameters = new { Id = id};
            const string query = "SELECT * FROM Bet_Services.Bets WHERE Id = @Id";
            return await _sqlUnitOfWork.ExecuteQuerySingle<Bet>(query, parameters);
        }

        public Task<List<Bet>> FindBy(Expression<Func<Bet, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        
        public async Task<List<Bet>> FindActiveBetsByRouletteId(long rouletteId)
        {
            var parameters = new { RouletteId = rouletteId};
            const string query = "SELECT * FROM Bet_Services.Bets WHERE RouletteId = @RouletteId AND EntityState = 1";
            return await _sqlUnitOfWork.ExecuteQuery<Bet>(query, parameters);
        }

        public void SaveRange(IEnumerable<Bet> entities)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Bet entity)
        {
            var parameters = new DynamicParameters(entity);
            const string query = "UPDATE Bet_Services.Bets SET Amount = @Amount, Type = @Type, Reward = @Reward, " +
                                 "CreationDate = @CreationDate, EntityState = @EntityState, " +
                                 "SelectedColor = @SelectedColor, SelectedNumber = @SelectedNumber, " +
                                 "UpdateTime = @UpdateTime " +
                                 "WHERE RouletteId = @RouletteId AND ClientId = @ClientId";
            await _sqlUnitOfWork.ExecuteCommandAsync(query, parameters);
        }

        public void UpdateRange(IEnumerable<Bet> entities)
        {
            throw new NotImplementedException();
        }

        public async Task Insert(Bet entity)
        {
            var parameters = new DynamicParameters(entity);
            const string query = "INSERT INTO bet_services.bets (RouletteId, ClientId, Amount, Type, " +
                                 "Reward, CreationDate, EntityState, SelectedColor, SelectedNumber, UpdateTime) " +
                                 "VALUES (@RouletteId, @ClientId, @Amount, @Type, " +
                                 "0, @CreationDate, @EntityState, @SelectedColor, @SelectedNumber, @UpdateTime)";
            await _sqlUnitOfWork.ExecuteCommandAsync(query, parameters);
        }
        
    }
}