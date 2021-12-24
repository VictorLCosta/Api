using System;

namespace Api.Domain.DTO.City
{
    public class UpdateCityResultDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int IbgeCode { get; set; }
        public Guid StateId { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}