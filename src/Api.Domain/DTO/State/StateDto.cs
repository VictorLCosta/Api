using System;

namespace Api.Domain.DTO.State
{
    public class StateDto
    {
        public Guid Id { get; set; }
        public string UF { get; set; }
        public string Name { get; set; }
    }
}