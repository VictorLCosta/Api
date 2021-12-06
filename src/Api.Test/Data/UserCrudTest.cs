using System;
using System.Threading.Tasks;
using Api.Data;
using Api.Data.Repositories;
using Api.Domain.Entities;
using Bogus;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Test.Data
{
    public class UserCrudTest : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;

        public UserCrudTest(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact]
        [Trait("CRUD", "User")]
        public async Task IsPossibleMakeUserCrud()
        {
            using (var context = _serviceProvider.GetService<ApplicationDbContext>())
            {
                Faker faker = new();

                UserRepository repository = new(context);
                User user = new() 
                {
                    Email = faker.Person.Email,
                    Name = faker.Person.FullName,
                };

                var result = await repository.AddAsync(user);

                Assert.NotNull(result);
                Assert.Equal("teste@mail.com", result.Email);
                Assert.Equal("TestName", result.Name);
                Assert.False(result.Id == Guid.Empty);

            }
        }
    }
}