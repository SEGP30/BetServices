using System;
using BetServices.Domain.Enums;

namespace BetServices.Domain.Base
{
    public class BaseEntity
    {
        public DateTime CreationDate { get; set; }
        public DateTime UpdateTime { get; set; }
        public EntityState EntityState { get; set; }
    }
}