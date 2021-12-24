using System;

namespace Api.Domain.DTO.City
{
    public class CreateCityResultDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int IbgeCode { get; set; }
        public Guid StateId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}