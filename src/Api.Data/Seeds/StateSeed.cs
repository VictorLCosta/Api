using System;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Seeds
{
    public static class StateSeed
    {
        public static void SeedState(this ModelBuilder builder)
        {
            builder.Entity<State>().HasData(
                new State()
                {
                    Id = Guid.NewGuid(),
                    UF = "AC",
                    Name = "Acre",
                    CreatedAt = DateTime.UtcNow
                },
                new State()
                {
                    Id = Guid.NewGuid(),
                    UF = "AL",
                    Name = "Alagoas",
                    CreatedAt = DateTime.UtcNow
                },
                new State()
                {
                    Id = Guid.NewGuid(),
                    UF = "AP",
                    Name = "Amapá",
                    CreatedAt = DateTime.UtcNow
                },
                new State()
                {
                    Id = Guid.NewGuid(),
                    UF = "AM",
                    Name = "Amazonas",
                },
                new State()
                {
                    Id = Guid.NewGuid(),
                    UF = "BA",
                    Name = "Bahia",
                    CreatedAt = DateTime.UtcNow
                },
                new State()
                {
                    Id = Guid.NewGuid(),
                    UF = "CE",
                    Name = "Ceará",
                    CreatedAt = DateTime.UtcNow
                },
                new State()
                {
                    Id = Guid.NewGuid(),
                    UF = "DF",
                    Name = "Distrito Federal",
                },
                new State()
                {
                    Id = Guid.NewGuid(),
                    UF = "ES",
                    Name = "Espírito Santo",
                },
                new State()
                {
                    Id = Guid.NewGuid(),
                    UF = "GO",
                    Name = "Goiás",
                    CreatedAt = DateTime.UtcNow
                },
                new State()
                {
                    Id = Guid.NewGuid(),
                    UF = "MA",
                    Name = "Maranhão",
                    CreatedAt = DateTime.UtcNow
                },
                new State()
                {
                    Id = Guid.NewGuid(),
                    UF = "MT",
                    Name = "Mato Grosso",
                    CreatedAt = DateTime.UtcNow
                },
                new State()
                {
                    Id = Guid.NewGuid(),
                    UF = "MS",
                    Name = "Mato Grosso do Sul",
                    CreatedAt = DateTime.UtcNow
                },
                new State()
                {
                    Id = Guid.NewGuid(),
                    UF = "MG",
                    Name = "Minas Gerais",
                    CreatedAt = DateTime.UtcNow
                },
                new State()
                {
                    Id = Guid.NewGuid(),
                    UF = "PA",
                    Name = "Pará",
                    CreatedAt = DateTime.UtcNow
                },
                new State()
                {
                    Id = Guid.NewGuid(),
                    UF = "PB",
                    Name = "Paraíba",
                    CreatedAt = DateTime.UtcNow
                },
                new State()
                {
                    Id = Guid.NewGuid(),
                    UF = "PR",
                    Name = "Paraná",
                    CreatedAt = DateTime.UtcNow
                },
                new State()
                {
                    Id = Guid.NewGuid(),
                    UF = "PE",
                    Name = "Pernambuco",
                    CreatedAt = DateTime.UtcNow
                },
                new State()
                {
                    Id = Guid.NewGuid(),
                    UF = "PI",
                    Name = "Piauí",
                    CreatedAt = DateTime.UtcNow
                },
                new State()
                {
                    Id = Guid.NewGuid(),
                    UF = "RR",
                    Name = "Roraima",
                    CreatedAt = DateTime.UtcNow
                },
                new State()
                {
                    Id = Guid.NewGuid(),
                    UF = "RO",
                    Name = "Rondônia",
                    CreatedAt = DateTime.UtcNow
                },
                new State()
                {
                    Id = Guid.NewGuid(),
                    UF = "RJ",
                    Name = "Rio de Janeiro",
                    CreatedAt = DateTime.UtcNow
                },
                new State()
                {
                    Id = Guid.NewGuid(),
                    UF = "RN",
                    Name = "Rio Grande do Norte",
                    CreatedAt = DateTime.UtcNow
                },
                new State()
                {
                    Id = Guid.NewGuid(),
                    UF = "RS",
                    Name = "Rio Grande do Sul",
                    CreatedAt = DateTime.UtcNow
                },
                new State()
                {
                    Id = Guid.NewGuid(),
                    UF = "SC",
                    Name = "Santa Catarina",
                    CreatedAt = DateTime.UtcNow
                },
                new State()
                {
                    Id = Guid.NewGuid(),
                    UF = "SP",
                    Name = "São Paulo",
                    CreatedAt = DateTime.UtcNow
                },
                new State()
                {
                    Id = Guid.NewGuid(),
                    UF = "SE",
                    Name = "Sergipe",
                    CreatedAt = DateTime.UtcNow
                },
                new State()
                {
                    Id = Guid.NewGuid(),
                    UF = "TO",
                    Name = "Tocantins",
                    CreatedAt = DateTime.UtcNow
                }
                
            );
        }
    }
}