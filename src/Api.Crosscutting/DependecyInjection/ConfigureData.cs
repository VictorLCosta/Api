using System;
using Api.Data;
using Api.Data.Interfaces;
using Api.Data.Repositories;
using Api.Data.Transactions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Api.Crosscutting.DependecyInjection
{
    public static class ConfigureData
    {
        public static IServiceCollection AddDataDependecies(this IServiceCollection services, IConfiguration config)
        {
            string connectionString = config.GetConnectionString("DefaultConnection");

            var version = ServerVersion.AutoDetect(connectionString);

            services.AddDbContext<ApplicationDbContext>(opt => {
                opt.UseMySql(connectionString, version);
            });

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

            services.AddTransient<IUow, Uow>();

            return services;
        }
    }
}