using System;
using Api.Domain.DTO.User;
using Api.Domain.Entities;
using Bogus;
using Xunit;

namespace Api.Test.Services.AutoMapper
{
    public class UserMapper : BaseServiceTest
    {
        [Fact]
        public void IsPossibleMapUser()
        {
            Faker faker = new();

            var model = new UserDto() 
            {
                Id = Guid.NewGuid(),
                Name = faker.Person.FullName,
                Email = faker.Person.Email,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var user = Mapper.Map<User>(model);

            Assert.Equal(model.Id, user.Id);
            Assert.Equal(model.Name, user.Name);
            Assert.Equal(model.Email, user.Email);
            Assert.Equal(model.CreatedAt, user.CreatedAt);
            Assert.Equal(model.UpdatedAt, user.UpdatedAt);
        }
    }
}