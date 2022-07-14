using System.Collections.Generic;
using BetServices.Domain.Entities;

namespace BetServices.Application.BetServices.Responses
{
    public class ClosingBetsResponse
    {
        public List<Bet> Bets { get; set; }
    }
}