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

        public void CalculateReward(int winnerNumber)
        {
            switch (Type)
            {
                case BetType.Numerical:
                    Reward = SelectedNumber == winnerNumber ? Amount * 5 : 0;
                    break;
                case BetType.Color:
                    switch (SelectedColor)
                    {
                        case Enums.SelectedColor.Black when winnerNumber % 2 == 1:
                        case Enums.SelectedColor.Red when winnerNumber % 2 == 0:
                            Reward = (long)(Amount * 1.8);
                            break;
                    }

                    break;
            }
        }
    }
}