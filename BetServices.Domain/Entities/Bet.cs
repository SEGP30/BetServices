using BetServices.Domain.Base;
using BetServices.Domain.Enums;

namespace BetServices.Domain.Entities
{
    public class Bet : Entity<long>
    {
        public long RouletteId { get; set; }
        public long ClientId { get; set; }
        public short Amount { get; set; }
        public long Reward { get; set; }
        public BetType Type { get; set; }
        public SelectedColor? SelectedColor { get; set; }
        public short? SelectedNumber { get; set; }
    }
}