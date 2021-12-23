using Api.Data.Mapping;
using Api.Data.Seeds;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Cep> Ceps { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<State> States { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);

            mb.ApplyConfiguration(new UserMap());
            mb.ApplyConfiguration(new CepMap());
            mb.ApplyConfiguration(new CityMap());
            mb.ApplyConfiguration(new StateMap());

            mb.SeedState();
        }
    }
}