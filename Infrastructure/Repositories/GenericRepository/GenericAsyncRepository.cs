using ApplicationCore.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.GenericRepository
{
    public class GenericAsyncRepository<T> : IGenericAsyncRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public GenericAsyncRepository(ApplicationDbContext context) => _context = context;

        public virtual async Task CreateAsync(T entity)
        {
          await _context.Set<T>().AddAsync(entity);
        }

        public virtual async Task DeleteAsync(T entity)
        {
             _context.Set<T>().Remove(entity);
        }

        public virtual async Task<T> GetByAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public virtual async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<IReadOnlyList<T>> ListAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public virtual async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
