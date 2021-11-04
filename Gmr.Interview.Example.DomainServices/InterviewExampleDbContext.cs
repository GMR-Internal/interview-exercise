using Gmr.Interview.Example.DomainModels;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Threading.Tasks;

namespace Gmr.Interview.Example.DomainServices
{
    public class InterviewExampleDbContext : DbContext, IInterviewExampleDbContext
    {
        private readonly ILogger _logger = Log.ForContext<InterviewExampleDbContext>();

        public InterviewExampleDbContext(DbContextOptions<InterviewExampleDbContext> options)
            : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                throw new System.ArgumentNullException(nameof(modelBuilder));
            }

            base.OnModelCreating(modelBuilder);

        }

        public async Task<int> SaveChangesAsync()
        {
            _logger.Information("SaveChangesAsync was called and we are saving data.");

            int saveResults = 0;

            try
            {
                saveResults = await base.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException ex)
            {
                var exception = ex;

                _logger.Error("DbUpdateConcurrencyException in SaveChangesAsync: ", ex);

                throw;
            }

            catch (DbUpdateException ex)
            {
                var exception = ex.InnerException;

                _logger.Error("DbUpdateException in SaveChangesAsync: ", ex);

                throw;
            }

            catch (Exception ex)
            {
                _logger.Error("General exception in SaveChangesAsync: ", ex);

                throw;
            }

            return saveResults;
        }
    }
}