using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.DTO.User;
using Bogus;
using Newtonsoft.Json;
using Xunit;

namespace Api.Test.Integration.User
{
    public class PostUserTest : BaseIntegration
    {
        private string _name { get; set; }
        private string _email { get; set; }
        private string _password { get; set; }

        [Fact]
        public async Task IsPossibleCreateUser()
        {
            Faker faker = new();
            _name = faker.Person.FullName;
            _email = faker.Person.Email;
            _password = faker.Internet.Password(8);

            var userDto = new UserDto()
            {
                Name = _name,
                Email = _email,
                Password = _password
            };

            var response = await PostJsonAsync(userDto, $"{HostApi}users", Client);
            var responseObj = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<CreateUserResultDto>(responseObj);

            Assert.Equal(response.StatusCode, HttpStatusCode.Created);
            Assert.Equal(responseData.Name, _name);
            Assert.Equal(responseData.Email, _email);
            Assert.True(responseData.Id != default(Guid));
        }
    }
}