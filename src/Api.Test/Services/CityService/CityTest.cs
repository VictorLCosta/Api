using System;
using System.Collections.Generic;
using Api.Domain.DTO.City;
using Api.Domain.DTO.State;
using Bogus;

namespace Api.Test.Services.CityService
{
    public class CityTest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UpdatedName { get; set; }
        public int IbgeCode { get; set; }
        public int UpdatedIbgeCode { get; set; }

        public Guid StateId { get; set; }

        public CityDto CityDto { get; set; } = new();
        public CreateCityDto CreateCity { get; set; } = new();
        public UpdateCityDto UpdateCity { get; set; } = new();
        public CreateCityResultDto CreateCityResult { get; set; } = new();
        public UpdateCityResultDto UpdateCityResult { get; set; } = new();
        public List<CityDto> CityList { get; set; } = new();

        public CityTest()
        {
            Faker faker = new("pt_BR");

            Id = Guid.NewGuid();
            Name = faker.Address.State();
            UpdatedName = faker.Address.State();
            IbgeCode = faker.Random.Number(100000, 999999);
            UpdatedIbgeCode = faker.Random.Number(100000, 999999);

            StateId = Guid.NewGuid();

            CityDto = new()
            {
                Id = Id,
                Name = Name,
                IbgeCode = IbgeCode,
                StateId = StateId,
                State = new()
                {
                    Id = StateId,
                    UF = faker.Address.StateAbbr(),
                    Name = faker.Address.State()
                }
            };

            CreateCity = new()
            {
                Name = Name,
                IbgeCode = IbgeCode,
                StateId = StateId
            };

            UpdateCity = new()
            {
                Id = Id,
                Name = UpdatedName,
                IbgeCode = UpdatedIbgeCode,
                StateId = StateId
            };

            CreateCityResult = new()
            {
                Id = Id,
                Name = Name,
                IbgeCode = IbgeCode,
                StateId = StateId,
            };

            UpdateCityResult = new()
            {
                Id = Id,
                Name = UpdatedName,
                IbgeCode = UpdatedIbgeCode,
                StateId = StateId,
            };

            for (int i = 0; i < 10; i++)
            {
                CityList.Add(new CityDto() {
                    Id = Guid.NewGuid(),
                    Name = faker.Person.FullName,
                    IbgeCode = faker.Random.Number(100000, 999999),
                    StateId = Guid.NewGuid(),
                    State = new()
                    {
                        Id = Guid.NewGuid(),
                        Name = faker.Address.State(),
                        UF = faker.Address.StateAbbr()
                    }
                });
            }
        }
    }
}