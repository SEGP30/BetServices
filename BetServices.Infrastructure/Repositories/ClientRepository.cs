using BetServices.Domain.Contracts;
using BetServices.Infrastructure.Base;
using Microsoft.EntityFrameworkCore;
using Client = BetServices.Domain.Entities.Client;

namespace BetServices.Infrastructure.Repositories
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(DbContext context) : base(context)
        {
        }
    }
}