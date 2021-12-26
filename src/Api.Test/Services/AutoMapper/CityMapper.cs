using System;
using Api.Domain.DTO.City;
using Api.Domain.Entities;
using Bogus;
using Xunit;

namespace Api.Test.Services.AutoMapper
{
    public class CityMapper : BaseServiceTest
    {
        [Fact]
        public void IsPossibleMapCity()
        {
            Faker faker = new("pt_BR");
            
            CityDto model = new()
            {
                Id = Guid.NewGuid(),
                Name = faker.Address.City(),
                IbgeCode = faker.Random.Number(100000, 999999),
                StateId = Guid.NewGuid(),
                State = new()
                {
                    Id = Guid.NewGuid(),
                    UF = faker.Address.StateAbbr(),
                    Name = faker.Address.State()
                }
            };

            CreateCityDto createModel = new()
            {
                Name = model.Name,
                IbgeCode = model.IbgeCode,
                StateId = model.StateId
            };

            UpdateCityDto updateModel = new()
            {
                Id = model.Id,
                Name = faker.Address.City(),
                IbgeCode = faker.Random.Number(100000, 999999),
                StateId = Guid.NewGuid()
            };

            var city = Mapper.Map<City>(model);

            Assert.Equal(model.Id, city.Id);
            Assert.Equal(model.Name, city.Name);
            Assert.Equal(model.IbgeCode, city.IbgeCode);

            city = Mapper.Map<City>(createModel);

            Assert.Equal(createModel.Name, city.Name);
            Assert.Equal(createModel.IbgeCode, city.IbgeCode);
            Assert.Equal(createModel.StateId, city.StateId);

            var createCityResult = Mapper.Map<CreateCityResultDto>(city);

            Assert.Equal(createCityResult.Id, city.Id);
            Assert.Equal(createCityResult.Name, city.Name);
            Assert.Equal(createCityResult.IbgeCode, city.IbgeCode);

            city = Mapper.Map<City>(updateModel);

            Assert.Equal(updateModel.Name, city.Name);
            Assert.Equal(updateModel.IbgeCode, city.IbgeCode);
            Assert.Equal(updateModel.StateId, city.StateId);

            var updateCityResult = Mapper.Map<UpdateCityDto>(city);

            Assert.Equal(updateCityResult.Id, city.Id);
            Assert.Equal(updateCityResult.Name, city.Name);
            Assert.Equal(updateCityResult.IbgeCode, city.IbgeCode);
        }
    }
}