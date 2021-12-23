using System.Collections.Generic;

namespace Api.Domain.Entities
{
    public class State : BaseEntity
    {
        public string UF { get; set; }
        public string Name { get; set; }

        public IEnumerable<City> Cities { get; set; }
    }
}