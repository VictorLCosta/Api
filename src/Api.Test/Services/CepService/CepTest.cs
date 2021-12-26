using System;
using System.Collections.Generic;
using Api.Domain.DTO.Cep;
using Bogus;
using Bogus.Extensions.Brazil;

namespace Api.Test.Services.CepService
{
    public class CepTest
    {
        public static Guid Id { get; set; }
        public static string CEP { get; set; }
        public static string UpdatedCEP { get; set; }
        public static string PublicPlace { get; set; }
        public static string UpdatedPublicPlace { get; set; }
        public static string Number { get; set; }
        public static string UpdatedNumber { get; set; }
        public static DateTime CreatedAt { get; set; }

        public static Guid CityId { get; set; }

        public List<CepDto> CepDtoList { get; set; } = new();
        public CepDto CepDto { get; set; } = new();
        public CreateCepDto CreateCep { get; set; } = new();
        public UpdateCepDto UpdateCep { get; set; } = new();
        public CreateCepResultDto CreateCepResult { get; set; } = new();
        public UpdateCepResultDto UpdateCepResult { get; set; } = new();

        public CepTest()
        {
            Faker faker = new();

            Id = Guid.NewGuid();
            CEP = faker.Address.ZipCode();
            UpdatedCEP = faker.Address.ZipCode();
            PublicPlace = faker.Address.StreetName();
            UpdatedPublicPlace = faker.Address.StreetName();
            Number = faker.Random.Number(10000, 99999).ToString();
            UpdatedNumber = faker.Random.Number(10000, 99999).ToString();
            CreatedAt = DateTime.UtcNow;
            CityId = Guid.NewGuid();

            for (int i = 0; i < 10; i++)
            {
                CepDtoList.Add(new CepDto()
                {
                    Id = Guid.NewGuid(),
                    CEP = faker.Person.FullName,
                    PublicPlace = faker.Address.StreetName(),
                    Number = faker.Random.Number(10000, 99999).ToString(),
                    CityId = Guid.NewGuid(),
                    City = new()
                    {
                        Id = CityId,
                        Name = faker.Address.City(),
                        IbgeCode = faker.Random.Number(1000000, 9999999),
                        StateId = Guid.NewGuid(),
                        State = new()
                        {
                            Id = Guid.NewGuid(),
                            UF = "SP",
                            Name = "São Paulo",
                        }
                    }
                });
            }

            CepDto = new()
            {
                Id = Id,
                CEP = CEP,
                PublicPlace = PublicPlace,
                Number = Number,
                CityId = CityId,
                City = new()
                {
                    Id = CityId,
                    Name = faker.Address.City(),
                    IbgeCode = faker.Random.Number(1000000, 9999999),
                    StateId = Guid.NewGuid(),
                    State = new()
                    {
                        Id = Guid.NewGuid(),
                        UF = "SP",
                        Name = "São Paulo",
                    }
                }
            };

            CreateCep = new()
            {
                CEP = CEP,
                PublicPlace = PublicPlace,
                Number = Number,
                CityId = CityId
            };

            UpdateCep = new()
            {
                Id = Id,
                CEP = UpdatedCEP,
                PublicPlace = UpdatedPublicPlace,
                Number = UpdatedNumber,
                CityId = CityId
            };

            CreateCepResult = new()
            {
                CEP = CEP,
                PublicPlace = PublicPlace,
                Number = Number,
                CityId = CityId
            };

            UpdateCepResult = new()
            {
                Id = Id,
                CEP = UpdatedCEP,
                PublicPlace = UpdatedPublicPlace,
                Number = UpdatedNumber,
                CityId = CityId
            };
        }
    }
}