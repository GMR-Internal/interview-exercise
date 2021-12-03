using Gmr.Interview.Example.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Gmr.Interview.Example.DomainServices.Repositories
{
    public class Repository<T> : IRepository<T>
        where T : BaseEntity
    {
        private readonly IInterviewExampleDbContext _context;

        private DbSet<T> _entities;

        public Repository(IInterviewExampleDbContext dbContext)
        {
            _context = dbContext;
            _entities = _context.Set<T>();
        }

        public Task<List<T>> GetAllAsync()
        {
            return _entities.ToListAsync();
        }

        public Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return _entities.Where(predicate).ToListAsync();
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _entities.FirstOrDefaultAsync(predicate);
        }

        public async Task<EntityEntry<T>> AddAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            return await _entities.AddAsync(entity);
        }

        public async Task<int> InsertAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            await _entities.AddAsync(entity);

            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _entities.Remove(entity);

            return await _context.SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
