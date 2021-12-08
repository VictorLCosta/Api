using System;
using System.Collections.Generic;
using Api.Domain.DTO.User;
using Bogus;

namespace Api.Test.Services
{
    public class UserTest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string UpdatedName { get; set; }
        public string UpdatedEmail { get; set; }

        public List<UserDto> UserDtoList { get; set; } = new List<UserDto>();
        public UserDto UserDto { get; set; } = new UserDto();
        public CreateUserResultDto CreateUserResult { get; set; } = new CreateUserResultDto();
        public UpdateUserResultDto UpdateUserResult { get; set; } = new UpdateUserResultDto();

        public UserTest()
        {
            var faker = new Faker();

            Id = Guid.NewGuid();
            Name = faker.Person.FullName;
            Email = faker.Person.Email;
            UpdatedName = faker.Person.FullName;
            UpdatedEmail = faker.Person.Email;

            for (int i = 0; i < 10; i++)
            {
                UserDtoList.Add(new UserDto() 
                {
                    Id = Guid.NewGuid(),
                    Name = faker.Person.FullName,
                    Email = faker.Person.Email,
                    Password = faker.Random.AlphaNumeric(9)
                });
            }

            UserDto = new UserDto() 
            {
                Id = Guid.NewGuid(),
                Name = faker.Person.FullName,
                Email = faker.Person.Email,
                Password = faker.Random.AlphaNumeric(9),
                CreatedAt = DateTime.UtcNow
            };

            CreateUserResult = new CreateUserResultDto() 
            {
                Id = Id,
                Name = Name,
                Email = Email,
                CreatedAt = DateTime.UtcNow
            };

            UpdateUserResult = new UpdateUserResultDto() 
            {
                Id = Id,
                Name = Name,
                Email = Email,
                UpdatedAt = DateTime.UtcNow
            };

        }
    }
}