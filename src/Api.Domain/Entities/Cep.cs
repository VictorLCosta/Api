using System;

namespace Api.Domain.Entities
{
    public class Cep : BaseEntity
    {
        public string CEP { get; set; }
        public string PublicPlace { get; set; }
        public string Number { get; set; }

        public Guid CityId { get; set; }
        public City City { get; set; }
    }
}