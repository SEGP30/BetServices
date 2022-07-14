using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BetServices.Domain.Contracts
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> FindAll();
        Task<T> Find(long id);
        Task<List<T>> FindBy(Expression<Func<T, bool>> predicate);
        void SaveRange(IEnumerable<T> entities);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
        Task Insert(T entity);
    }
}