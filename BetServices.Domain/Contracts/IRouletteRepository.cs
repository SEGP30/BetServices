using System.Threading.Tasks;
using BetServices.Domain.Entities;

namespace BetServices.Domain.Contracts
{
    public interface IRouletteRepository : IGenericRepository<Roulette> //IGenericDistributedCacheService
    {
        Task<Roulette> FindOpenRoulette(long id);
        Task<Roulette> FindUnnoperativeRoulette(long id);
    }
}