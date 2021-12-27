using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.DTO.City;
using Bogus;
using Newtonsoft.Json;
using Xunit;

namespace Api.Test.Integration.City
{
    public class CrudCityTest : BaseIntegration
    {
        private string _name { get; set; }
        private int _ibgeCode { get; set; }

        [Fact]
        public async Task IsPossibleMakeCityCrud()
        {
            await AddTokenAsync();

            Faker faker = new("pt_BR");

            _name = faker.Address.City();
            _ibgeCode = faker.Random.Number(100000, 999999);

            var createCityDto = new CreateCityDto()
            {
                Name = _name,
                IbgeCode = _ibgeCode,
                StateId = new("5daf0fe5-8f3c-4154-9a02-4461b24ef4b4")
            };

            var response = await PostJsonAsync(createCityDto, $"{HostApi}city", Client);
            var responseJson = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<CreateCityResultDto>(responseJson);

            Assert.Equal(response.StatusCode, HttpStatusCode.Created);
            Assert.Equal(responseData.Name, _name);
            Assert.Equal(responseData.IbgeCode, _ibgeCode);

            response = await Client.GetAsync($"{HostApi}city/{responseData.Id}");
            responseJson = await response.Content.ReadAsStringAsync();
            var responseGetById = JsonConvert.DeserializeObject<CityDto>(responseJson);

            Assert.Equal(response.StatusCode, HttpStatusCode.OK);
            Assert.Equal(responseGetById.Name, _name);
            Assert.Equal(responseGetById.IbgeCode, _ibgeCode);
            Assert.NotEqual(responseGetById.Id, default(Guid));

            response = await Client.GetAsync($"{HostApi}city/byIbge/{responseData.IbgeCode}");
            responseJson = await response.Content.ReadAsStringAsync();
            var responseGetByIbge = JsonConvert.DeserializeObject<CityDto>(responseJson);

            Assert.Equal(response.StatusCode, HttpStatusCode.OK);
            Assert.Equal(responseGetByIbge.Name, _name);
            Assert.Equal(responseGetByIbge.IbgeCode, _ibgeCode);
            Assert.NotEqual(responseGetByIbge.Id, default(Guid));

            response = await Client.GetAsync($"{HostApi}city");
            responseJson = await response.Content.ReadAsStringAsync();
            var responseGetAll = JsonConvert.DeserializeObject<List<CityDto>>(responseJson);

            Assert.Equal(response.StatusCode, HttpStatusCode.OK);
            Assert.NotEmpty(responseGetAll);
            Assert.True(responseGetAll.Select(x => x.Id).Contains(responseGetByIbge.Id));

            var updateCityDto = new UpdateCityDto()
            {
                Id = responseGetByIbge.Id,
                Name = faker.Address.City(),
                IbgeCode = faker.Random.Number(100000, 999999),
                StateId = responseGetByIbge.StateId
            };

            response = await PutJsonAsync(updateCityDto, $"{HostApi}city", Client);
            responseJson = await response.Content.ReadAsStringAsync();
            var responseUpdate = JsonConvert.DeserializeObject<UpdateCityResultDto>(responseJson);

            Assert.Equal(response.StatusCode, HttpStatusCode.OK);
            Assert.Equal(responseUpdate.Name, updateCityDto.Name);
            Assert.Equal(responseUpdate.IbgeCode, updateCityDto.IbgeCode);

            response = await Client.DeleteAsync($"{HostApi}city/{responseData.Id}");
            responseJson = await response.Content.ReadAsStringAsync();

            Assert.Equal(response.StatusCode, HttpStatusCode.OK);
            Assert.True(Boolean.Parse(responseJson));
            
        }
    }
}