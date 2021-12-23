using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
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
        public async Task IsPossibleMakeUserCrud()
        {
            Faker faker = new();

            _name = faker.Person.FullName;
            _email = faker.Person.Email;
            _password = faker.Internet.Password(10);

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

            await AddTokenAsync();
            
            response = await Client.GetAsync($"{HostApi}users");
            responseObj = await response.Content.ReadAsStringAsync();
            var listUsers = JsonConvert.DeserializeObject<IEnumerable<UserDto>>(responseObj);

            Assert.Equal(response.StatusCode, HttpStatusCode.OK);
            Assert.True(listUsers.Count() > 0);
            Assert.True(listUsers.Select(x => x.Id).Contains(responseData.Id));

            response = await Client.GetAsync($"{HostApi}users/{responseData.Id}");
            responseObj = await response.Content.ReadAsStringAsync();
            var createdUser = JsonConvert.DeserializeObject<UserDto>(responseObj);

            Assert.Equal(response.StatusCode, HttpStatusCode.OK);
            Assert.NotNull(createdUser);
            Assert.Equal(createdUser.Email, _email);
            Assert.Equal(createdUser.Name, _name);
            Assert.True(createdUser.Id != default(Guid));

            createdUser.Name = faker.Person.FullName;
            createdUser.Email = faker.Person.Email;
            createdUser.Password = faker.Internet.Password(10);

            var stringContent = new StringContent(JsonConvert.SerializeObject(createdUser), Encoding.UTF8, "application/json");

            response = await Client.PutAsync($"{HostApi}users", stringContent);
            responseObj = await response.Content.ReadAsStringAsync();
            var updatedUser = JsonConvert.DeserializeObject<UpdateUserResultDto>(responseObj);

            Assert.Equal(response.StatusCode, HttpStatusCode.OK);
            Assert.Equal(updatedUser.Email, createdUser.Email);
            Assert.Equal(updatedUser.Name, createdUser.Name);
            Assert.NotEqual(updatedUser.Name, _name);
            Assert.NotEqual(updatedUser.Email, _email);

            response = await Client.DeleteAsync($"{HostApi}users/{responseData.Id}");
            responseObj = await response.Content.ReadAsStringAsync();
            
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);
            Assert.True(Boolean.Parse(responseObj));
        }

    }
}