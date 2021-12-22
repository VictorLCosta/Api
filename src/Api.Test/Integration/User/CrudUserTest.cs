using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.DTO.User;
using Bogus;
using Newtonsoft.Json;
using Xunit;

namespace Api.Test.Integration.User
{
    public class CrudUserTest : BaseIntegration
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

        [Fact]
        public async Task IsPossibleGetAllUsers()
        {
            await AddTokenAsync();

            var response = await Client.GetAsync($"{HostApi}users");
            var responseObj = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<IEnumerable<UserDto>>(responseObj);

            Assert.Equal(response.StatusCode, HttpStatusCode.OK);
            Assert.True(responseData.Count() > 0);
        }

        [Fact]
        public async Task IsPossibleGetUser()
        {
            var id = "2bce5034-a82a-471d-a108-4c1007803e45";

            var response = await Client.GetAsync($"{HostApi}users/{id}");
            var responseObj = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<UserDto>(responseObj);

            Assert.Equal(response.StatusCode, HttpStatusCode.OK);
            Assert.NotNull(responseData);
        }

        [Fact]
        public async Task IsPossibleDeleteUser()
        {
            var id = "2bce5034-a82a-471d-a108-4c1007803e45";

            var response = await Client.DeleteAsync($"{HostApi}users/{id}");
            var responseObj = await response.Content.ReadAsStringAsync();

            Assert.Equal(response.StatusCode, HttpStatusCode.OK);
            Assert.True(Boolean.Parse(responseObj));
        }
    }
}