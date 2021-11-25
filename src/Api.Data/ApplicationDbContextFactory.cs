using Pomelo.EntityFrameworkCore.MySql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Api.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        private readonly IConfiguration _config;

        public ApplicationDbContextFactory(IConfiguration config)
        {
            _config = config;
        }

        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var connectionString = _config.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseMySql(connectionString, null);
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}