using System;
using Api.Domain.DTO.City;

namespace Api.Domain.DTO.Cep
{
    public class CepDto
    {
        public Guid Id { get; set; }
        public string CEP { get; set; }
        public string PublicPlace { get; set; }
        public string Number { get; set; }

        public Guid CityId { get; set; }
        public CityDto City { get; set; }
    }
}