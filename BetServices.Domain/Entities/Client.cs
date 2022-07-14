using BetServices.Domain.Base;
using BetServices.Domain.Enums;

namespace BetServices.Domain.Entities
{
    public class Client : Entity<long>
    {
        public string Names { get; set; }
        public string Surnames { get; set; }
        public Gender Gender { get; set; }
        public long Credit { get; set; }
    }
}