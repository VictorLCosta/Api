using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.DTO.Cep;
using Bogus;
using Newtonsoft.Json;
using Xunit;

namespace Api.Test.Integration.Cep
{
    public class CrudCepTest : BaseIntegration
    {
        private string _cep { get; set; }
        private string _publicPlace { get; set; }
        private string _number { get; set; }

        [Fact]
        public async Task IsPossibleMakeCepCrud()
        {
            await AddTokenAsync();

            Faker faker = new("pt_BR");

            _cep = faker.Address.ZipCode();
            _publicPlace = faker.Address.StreetName();
            _number = faker.Random.Number(1000, 9999).ToString();

            var createCepDto = new CreateCepDto()
            {
                CEP = _cep,
                PublicPlace = _publicPlace,
                Number = _number,
                CityId = new("08d9c8cd-de5c-40f0-8d81-f5d31d2bf1a8")
            };

            var response = await PostJsonAsync(createCepDto, $"{HostApi}cep", Client);
            var responseJson = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<CreateCepResultDto>(responseJson);

            Assert.Equal(response.StatusCode, HttpStatusCode.Created);
            Assert.Equal(responseData.CEP, _cep);
            Assert.Equal(responseData.PublicPlace, _publicPlace);

            response = await Client.GetAsync($"{HostApi}cep/{responseData.Id}");
            responseJson = await response.Content.ReadAsStringAsync();
            var responseGetById = JsonConvert.DeserializeObject<CepDto>(responseJson);

            Assert.Equal(response.StatusCode, HttpStatusCode.OK);
            Assert.Equal(responseGetById.CEP, _cep);
            Assert.Equal(responseGetById.PublicPlace, _publicPlace);
            Assert.NotEqual(responseGetById.Id, default(Guid));

            response = await Client.GetAsync($"{HostApi}cep/byCep/{responseData.CEP}");
            responseJson = await response.Content.ReadAsStringAsync();
            var responseGetByCep = JsonConvert.DeserializeObject<CepDto>(responseJson);

            Assert.Equal(response.StatusCode, HttpStatusCode.OK);
            Assert.Equal(responseData.CEP, _cep);
            Assert.Equal(responseData.PublicPlace, _publicPlace);
            Assert.NotEqual(responseGetById.Id, default(Guid));

            var updateCepDto = new UpdateCepDto()
            {
                Id = responseGetByCep.Id,
                CEP = faker.Address.ZipCode(),
                PublicPlace = faker.Address.StreetName(),
                Number = faker.Random.Number(100000, 999999).ToString(),
                CityId = responseGetByCep.CityId
            };

            response = await PutJsonAsync(updateCepDto, $"{HostApi}cep", Client);
            responseJson = await response.Content.ReadAsStringAsync();
            var responsePut = JsonConvert.DeserializeObject<UpdateCepResultDto>(responseJson);

            Assert.Equal(response.StatusCode, HttpStatusCode.OK);
            Assert.Equal(responsePut.CEP, updateCepDto.CEP);
            Assert.Equal(responsePut.PublicPlace, updateCepDto.PublicPlace);
            Assert.Equal(responsePut.Number, updateCepDto.Number);

            response = await Client.DeleteAsync($"{HostApi}cep/{responseData.Id}");
            responseJson = await response.Content.ReadAsStringAsync();

            Assert.Equal(response.StatusCode, HttpStatusCode.OK);
            Assert.True(Boolean.Parse(responseJson));

        }

    }
}