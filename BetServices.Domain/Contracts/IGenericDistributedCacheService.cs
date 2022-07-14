using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BetServices.Domain.Contracts
{
    public interface IGenericDistributedCacheService
    {
        T Get<T>(string key);
        T Set<T>(string key, T value); 
    }
}