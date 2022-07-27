using System.Threading.Tasks;

namespace BetServices.Domain.Contracts
{
    public interface IUnitOfWork
    {
        IRouletteRepository RouletteRepository { get; }
        IBetRepository BetRepository { get; }
        IClientRepository ClientRepository { get; }
        

        Task Commit();
    }
}