using System;
using Api.Domain.DTO.State;

namespace Api.Domain.DTO.City
{
    public class CityDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int IbgeCode { get; set; }

        public Guid StateId { get; set; }
        public StateDto State { get; set; }
    }
}