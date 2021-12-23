using System;
using System.Collections.Generic;

namespace Api.Domain.Entities
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public int IbgeCode { get; set; }

        public State State { get; set; }
        public Guid StateId { get; set; }

        public IEnumerable<Cep> Ceps { get; set; }
    }
}