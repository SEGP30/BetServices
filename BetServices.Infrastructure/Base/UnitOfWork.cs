using System.Threading.Tasks;
using BetServices.Domain.Contracts;
using BetServices.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BetServices.Infrastructure.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        /*private IRouletteRepository _rouletteRepository { get; set; }
        private IBetRepository _betRepository { get; set; }
        private IClientRepository _clientRepository { get; set; }

        public IRouletteRepository RouletteRepository
        {
            get { return _rouletteRepository ??= new RouletteRepository(_dbContext); }
        }
        
        public IClientRepository ClientRepository
        {
            get { return _clientRepository ??= new ClientRepository(_dbContext); }
        }

        public IBetRepository BetRepository
        {
            get { return _betRepository ??= new BetRepository(_dbContext); }
        } */

        public IRouletteRepository RouletteRepository => throw new System.NotImplementedException();

        public IBetRepository BetRepository => throw new System.NotImplementedException();

        public IClientRepository ClientRepository => throw new System.NotImplementedException();

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }

        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
    }
}