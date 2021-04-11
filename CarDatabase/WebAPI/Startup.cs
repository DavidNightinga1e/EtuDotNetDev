using AutoMapper;
using CarDatabase.Business.Contracts;
using CarDatabase.Business.Implementations;
using CarDatabase.DataAccess.Context;
using CarDatabase.DataAccess.Contracts;
using CarDatabase.DataAccess.Implementation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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

            services.AddScoped<ICreateCarService, CreateCarService>();
            services.AddScoped<IGetCarService, GetCarService>();
            services.AddScoped<IGetOwnerService, GetOwnerService>();
            services.AddScoped<ICreateOwnerService, CreateOwnerService>();
            
            services.AddTransient<ICarDataAccess, CarDataAccess>();
            services.AddTransient<IOwnerDataAccess, OwnerDataAccess>();
            
            services.AddDbContext<CarDatabaseContext>(t =>
                t.UseSqlServer(Configuration.GetConnectionString("CarDatabase")));
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