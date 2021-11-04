using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Gmr.Interview.Example.DomainServices
{
    public interface IDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync();

        void Dispose();
    }
}