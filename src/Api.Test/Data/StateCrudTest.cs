using System;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.Data.Repositories;
using Api.Domain.Entities;
using Bogus;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Test.Data
{
    public class StateCrudTest : BaseDataTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;

        public StateCrudTest(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact]
        public async Task IsPossibleMakeStateCrud()
        {
            using (var context = _serviceProvider.GetService<ApplicationDbContext>())
            {
                Faker faker = new();

                StateRepository repository = new(context);
                State state = new()
                {
                    Id = Guid.NewGuid(),
                    UF = "SP",
                    Name = "São Paulo",
                    CreatedAt = DateTime.UtcNow
                };

                var resultCreated = await repository.AddAsync(state);
                await context.SaveChangesAsync();
                Assert.NotNull(resultCreated);
                Assert.Equal(state.UF, resultCreated.UF);
                Assert.Equal(state.Name, resultCreated.Name);
                Assert.Equal(state.Id, resultCreated.Id);
                
                var resultExists = await repository.ExistAsync(state.Id);
                Assert.True(resultExists);

                var resultGet = await repository.GetAsync(state.Id);
                Assert.NotNull(resultGet);
                Assert.Equal(state.UF, resultGet.UF);
                Assert.Equal(state.Name, resultGet.Name);

                var resultGetAll = await repository.GetAllAsync();
                Assert.NotEmpty(resultGetAll);
                Assert.True(resultGetAll.Count() > 0);

                var resultDelete = await repository.Remove(state.Id);
                await context.SaveChangesAsync();
            }
        }
    }
}