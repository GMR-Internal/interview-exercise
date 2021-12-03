using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gmr.Interview.Example.ApplicationServices.Interfaces;
using Gmr.Interview.Example.ApplicationServices.Services;
using Gmr.Interview.Example.DomainServices;
using Gmr.Interview.Example.DomainServices.Repositories;
using Gmr.Interview.Example.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Gmr.Interview.Example.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<InterviewExampleDbContext>(options => 
                options.UseSqlite(Configuration.GetConnectionString("GMRDatabase"))
            );

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Gmr.Interview.Example.Api", Version = "v1" });
            });

            services.AddAutoMapper(typeof(MapperProfile));

            services.AddTransient<IInterviewExampleDbContext, InterviewExampleDbContext>();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IProjectService, ProjectService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gmr.Interview.Example.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
