using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarDatabase.Business.Contracts;
using CarDatabase.Business.Implementations;
using CarDatabase.DataAccess.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CarDatabase.WebAPI
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
            services.AddAutoMapper(typeof(Startup));

            services.Add(new ServiceDescriptor(typeof(ICreateCarService), typeof(CreateCarService),
                ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IGetCarService), typeof(GetCarService),
                ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IGetOwnerService), typeof(GetOwnerService),
                ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(ICreateOwnerService), typeof(CreateOwnerService),
                ServiceLifetime.Scoped));
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}