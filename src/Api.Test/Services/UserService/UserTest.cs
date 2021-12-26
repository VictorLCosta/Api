using System;
using System.Collections.Generic;
using Api.Domain.DTO.User;
using Bogus;

namespace Api.Test.Services.UserService
{
    public class UserTest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string UpdatedName { get; set; }
        public string UpdatedEmail { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<UserDto> UserDtoList { get; set; } = new List<UserDto>();
        public UserDto UserDto { get; set; } = new UserDto();
        public CreateUserResultDto CreateUserResult { get; set; } = new CreateUserResultDto();
        public UpdateUserResultDto UpdateUserResult { get; set; } = new UpdateUserResultDto();

        public UserTest()
        {
            var faker = new Faker("pt_BR");

            Id = Guid.NewGuid();
            Name = faker.Person.FullName;
            Email = faker.Person.Email;
            UpdatedName = faker.Person.FullName;
            UpdatedEmail = faker.Person.Email;
            CreatedAt = DateTime.UtcNow;

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
                Id = Id,
                Name = Name,
                Email = Email,
                Password = faker.Random.AlphaNumeric(9),
                CreatedAt = CreatedAt
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
                Name = UpdatedName,
                Email = UpdatedEmail,
                UpdatedAt = DateTime.UtcNow
            };

        }
    }
}