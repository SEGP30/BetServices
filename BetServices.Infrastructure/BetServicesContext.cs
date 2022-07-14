using BetServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BetServices.Infrastructure
{
    public class BetServicesContext : DbContext
    {
        public DbSet<Bet> Bets { get; set; }
        public DbSet<Roulette> Roulettes { get; set; }
        public DbSet<Client> Clients { get; set; }

        public BetServicesContext(DbContextOptions options) : base(options)
        {
        }
    }
}