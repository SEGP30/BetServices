using BetServices.Domain.Contracts;
using BetServices.Domain.Entities;
using BetServices.Infrastructure.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

namespace BetServices.Infrastructure.Repositories
{
    public class RouletteRepository : /* GenericDistributedCacheService */ GenericRepository<Roulette>, IRouletteRepository
    {
        public RouletteRepository(DbContext context) : base(context)
        {
        }
    }
}