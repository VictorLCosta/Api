using System;
using Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Test.Data
{
    public abstract class BaseDataTest
    {
        public BaseDataTest()
        {
            
        }
    }

    public class DbTest : IDisposable
    {
        private string dbName = $"dbApiTest_{Guid.NewGuid().ToString().Replace("-", string.Empty)}";
        public ServiceProvider ServiceProvider { get; set; }

        public DbTest()
        {
            ServiceCollection services = new();
            services.AddDbContext<ApplicationDbContext>(x =>
                x.UseInMemoryDatabase(dbName),
                ServiceLifetime.Transient
            );

            ServiceProvider = services.BuildServiceProvider();
            using (var context = ServiceProvider.GetService<ApplicationDbContext>())
            {
                context.Database.EnsureCreated();
            }
        }


        public async void Dispose()
        {
            using (var context = ServiceProvider.GetService<ApplicationDbContext>())
            {
                await context.Database.EnsureDeletedAsync();
            }
        }
    }
}