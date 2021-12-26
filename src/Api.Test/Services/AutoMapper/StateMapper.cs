using System;
using Api.Domain.DTO.State;
using Api.Domain.Entities;
using Bogus;
using Xunit;

namespace Api.Test.Services.AutoMapper
{
    public class StateMapper : BaseServiceTest
    {
        [Fact]
        public void IsPossibleMapState()
        {
            Faker faker = new("pt_BR");

            StateDto model = new()
            {
                Id = Guid.NewGuid(),
                UF = faker.Address.StateAbbr(),
                Name = faker.Address.State()
            };

            var state = Mapper.Map<State>(model);

            Assert.Equal(model.Id, state.Id);
            Assert.Equal(model.Name, state.Name);
            Assert.Equal(model.UF, state.UF);
        }
    }
}