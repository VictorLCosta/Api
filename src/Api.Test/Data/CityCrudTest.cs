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
    public class CityCrudTest : BaseDataTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;

        public CityCrudTest(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact]
        public async Task IsPossibleMakeCityCrud()
        {
            using (var context = _serviceProvider.GetService<ApplicationDbContext>())
            {
                Faker faker = new();

                CityRepository repository = new(context);
                State state = new()
                {
                    Id = Guid.NewGuid(),
                    UF = "EF",
                    Name = ""
                };

                City city = new()
                {
                    Name = faker.Address.City(),
                    IbgeCode = faker.Random.Number(1000000, 9999999),
                    StateId = state.Id,
                    State = state
                };

                var resultCreated = await repository.AddAsync(city);
                await context.SaveChangesAsync();
                Assert.NotNull(resultCreated);
                Assert.Equal(resultCreated.Id, city.Id);
                Assert.Equal(resultCreated.Name, city.Name);
                Assert.Equal(resultCreated.IbgeCode, city.IbgeCode);

                city.Name = faker.Address.City();
                city.IbgeCode = faker.Random.Number(1000000, 9999999);
                city.Id = resultCreated.Id;
                var resultUpdated = await repository.Update(city);
                await context.SaveChangesAsync();
                Assert.NotNull(resultUpdated);
                Assert.Equal(resultUpdated.Name, resultCreated.Name);
                Assert.Equal(resultUpdated.IbgeCode, resultCreated.IbgeCode);

                var resultExists = await repository.ExistAsync(resultUpdated.Id);
                Assert.True(resultExists);

                var resultGetById = await repository.GetByIdAsync(resultUpdated.Id);
                Assert.NotNull(resultGetById);
                Assert.Equal(resultGetById.Id, resultUpdated.Id);
                Assert.Equal(resultGetById.Name, resultUpdated.Name);
                Assert.Equal(resultGetById.IbgeCode, resultUpdated.IbgeCode);

                var resultGetByIbgeCode = await repository.GetByIbgeCodeAsync(resultUpdated.IbgeCode);
                Assert.NotNull(resultGetByIbgeCode);
                Assert.Equal(resultGetByIbgeCode.Id, resultUpdated.Id);
                Assert.Equal(resultGetByIbgeCode.Name, resultUpdated.Name);
                Assert.Equal(resultGetByIbgeCode.IbgeCode, resultUpdated.IbgeCode);

                var resultDelete = await repository.Remove(resultUpdated.Id);
                await context.SaveChangesAsync();
                Assert.True(resultDelete);

                var resultGetAll = await repository.GetAllAsync();
                Assert.True(resultGetAll.Count() == 0);
            }
        }
    }
}