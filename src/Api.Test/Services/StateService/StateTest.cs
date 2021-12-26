using System;
using System.Collections.Generic;
using Api.Domain.DTO.State;
using Bogus;

namespace Api.Test.Services.StateService
{
    public class StateTest
    {
        public Guid Id { get; set; }
        public string UF { get; set; }
        public string Name { get; set; }

        public StateDto StateDto { get; set; }
        public List<StateDto> StateList { get; set; } = new();

        public StateTest()
        {
            Faker faker = new("pt_BR");

            Id = Guid.NewGuid();
            UF = faker.Address.StateAbbr();
            Name = faker.Address.State();

            StateDto = new()
            {
                Id = Id,
                UF = UF,
                Name = Name
            };

            for (int i = 0; i < 10; i++)
            {
                StateList.Add(new StateDto() {
                    Id = Guid.NewGuid(),
                    UF = faker.Address.StateAbbr(),
                    Name = faker.Address.State()
                });
            }
        }
    }
}