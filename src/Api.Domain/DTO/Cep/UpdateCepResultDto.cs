using System;

namespace Api.Domain.DTO.Cep
{
    public class UpdateCepResultDto
    {
        public Guid Id { get; set; }
        public string CEP { get; set; }
        public string PublicPlace { get; set; }
        public string Number { get; set; }
        public Guid CityId { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}