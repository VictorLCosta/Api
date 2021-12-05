using System;
using Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Test
{
    public abstract class BaseTest
    {
        public BaseTest()
        {
            
        }
    }

    public class DbTest : IDisposable
    {
        private string dbName = $"dbApiTest_{Guid.NewGuid().ToString().Replace("-", string.Empty)}";
        public ServiceProvider ServiceProvider { get; set; }

        public DbTest()
        {
            var connectionString = $"Server=localhost;Database={dbName};Uid=root;Pwd=Icaronon9@;";
            var version = ServerVersion.AutoDetect(connectionString);

            ServiceCollection services = new();
            services.AddDbContext<ApplicationDbContext>(x =>
                x.UseMySql(connectionString, version),
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