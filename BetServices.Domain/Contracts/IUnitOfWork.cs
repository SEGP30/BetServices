using System.Threading.Tasks;

namespace BetServices.Domain.Contracts
{
    public interface IUnitOfWork
    {
        IBetRepository BetRepository { get; }
        IRouletteRepository RouletteRepository { get; }
        IClientRepository ClientRepository { get; }

        Task Commit();
    }
}