using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gmr.Interview.Example.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Gmr.Interview.Example.DomainServices
{
    public interface IInterviewExampleDbContext : IDbContext
    {
        DatabaseFacade Database { get; }

        IModel Model { get; }

        DbSet<Customer> Customers { get; set; }

        DbSet<Employee> Employees { get; set; }

        DbSet<Project> Projects { get; set; }
    }
}