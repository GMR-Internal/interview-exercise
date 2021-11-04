using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Gmr.Interview.Example.DomainServices.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync();

        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        Task<EntityEntry<TEntity>> AddAsync(TEntity entity);

        Task<int> InsertAsync(TEntity entity);

        Task<int> UpdateAsync(TEntity entity);

        Task<int> DeleteAsync(TEntity entity);

        Task<int> SaveChangesAsync();
    }
}