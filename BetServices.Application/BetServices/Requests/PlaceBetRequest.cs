using BetServices.Domain.Enums;

namespace BetServices.Application.BetServices.Requests
{
    public class PlaceBetRequest
    {
        public long RouletteId { get; set; }
        public long ClientId { get; set; }
        public BetType BetType { get; set; }
        public short SelectedNumber { get; set; }
        public SelectedColor SelectedColor { get; set; }
        public short Amount { get; set; }
        
    }
}