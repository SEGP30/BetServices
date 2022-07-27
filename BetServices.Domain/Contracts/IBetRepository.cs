using System.Collections.Generic;
using System.Threading.Tasks;
using BetServices.Domain.Entities;

namespace BetServices.Domain.Contracts
{
    public interface IBetRepository : IGenericRepository<Bet> //IGenericDistributedCacheService
    {
        Task<List<Bet>> FindActiveBetsByRouletteId(long rouletteId);
    }
}