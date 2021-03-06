using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MISA.Core.Interface.Service;
using MISA.Core.Service;
using MISA.Core.Interface.Repository;
using MISA.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MISA.CukCuk.Api.Middware;

namespace MISA.CukCuk.Api
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MISA.CukCuk.Api", Version = "v1" });
            });
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerGroupService, CustomerGroupService>();
            services.AddScoped<ICustomerGroupRepository, CustomerGroupRepository>();

            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MISA.CukCuk.Api v1"));
            }
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
