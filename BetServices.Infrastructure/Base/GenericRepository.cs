using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BetServices.Domain.Base;
using BetServices.Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BetServices.Infrastructure.Base
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DbSet<T> _dbSet;

        protected GenericRepository(DbContext context)
        {
            _dbSet = context.Set<T>();
        }
        
        public async Task<IEnumerable<T>> FindAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> Find(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<T>> FindBy(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async void SaveRange(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public void UpdateRange(IEnumerable<T> entities)
        { 
            _dbSet.UpdateRange(entities);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public async Task Insert(T entity)
        {
            await _dbSet.AddAsync(entity);
        }
    }
}