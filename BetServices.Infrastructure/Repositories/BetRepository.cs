using BetServices.Domain.Contracts;
using BetServices.Domain.Entities;
using BetServices.Infrastructure.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

namespace BetServices.Infrastructure.Repositories
{
    public class BetRepository : /*GenericDistributedCacheService */ GenericRepository<Bet>, IBetRepository
    {
        public BetRepository(DbContext context) : base(context)
        {
        }
    }
}