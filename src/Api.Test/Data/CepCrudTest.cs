using System;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.Data.Repositories;
using Api.Domain.Entities;
using Bogus;
using Bogus.Extensions.Brazil;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Test.Data
{
    public class CepCrudTest : BaseDataTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;

        public CepCrudTest(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact]
        public async Task IsPossibleMakeCepCrud()
        {
            using (var context = _serviceProvider.GetService<ApplicationDbContext>())
            {
                Faker faker = new();

                CepRepository repository = new(context);
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

                Cep cep = new()
                {
                    CEP = faker.Person.Cpf(),
                    PublicPlace = faker.Address.StreetName(),
                    Number = faker.Random.Number(0, 2000).ToString(),
                    CityId = city.Id,
                    City = city
                };

                var resultCreated = await repository.AddAsync(cep);
                await context.SaveChangesAsync();
                Assert.NotNull(resultCreated);
                Assert.Equal(resultCreated.Id, cep.Id);
                Assert.Equal(resultCreated.CEP, cep.CEP);
                Assert.Equal(resultCreated.PublicPlace, cep.PublicPlace);

                cep.CEP = faker.Person.Cpf();
                cep.PublicPlace = faker.Address.StreetName();
                cep.Id = resultCreated.Id;
                var resultUpdated = await repository.Update(cep);
                await context.SaveChangesAsync();
                Assert.NotNull(resultUpdated);
                Assert.Equal(resultUpdated.CEP, resultCreated.CEP);
                Assert.Equal(resultUpdated.PublicPlace, resultCreated.PublicPlace);

                var resultExists = await repository.ExistAsync(resultUpdated.Id);
                Assert.True(resultExists);

                var resultGetById = await repository.GetByIdAsync(resultUpdated.Id);
                Assert.NotNull(resultGetById);
                Assert.Equal(resultGetById.Id, resultUpdated.Id);
                Assert.Equal(resultGetById.CEP, resultUpdated.CEP);
                Assert.Equal(resultGetById.PublicPlace, resultUpdated.PublicPlace);

                var resultGetByCep = await repository.GetByCepAsync(resultUpdated.CEP);
                Assert.NotNull(resultGetByCep);
                Assert.Equal(resultGetByCep.Id, resultUpdated.Id);
                Assert.Equal(resultGetByCep.CEP, resultUpdated.CEP);
                Assert.Equal(resultGetByCep.PublicPlace, resultUpdated.PublicPlace);

                var resultDelete = await repository.Remove(resultUpdated.Id);
                await context.SaveChangesAsync();
                Assert.True(resultDelete);

                var resultGetAll = await repository.GetAllAsync();
                Assert.True(resultGetAll.Count() == 0);
            }
        }

    }
}