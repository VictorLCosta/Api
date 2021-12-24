using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.DTO.Cep
{
    public class UpdateCepDto
    {
        [Required(ErrorMessage = "O ID é um campo obrigatório")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "CEP é um campo obrigatório")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "Logradouro é um campo obrigatório")]
        public string PublicPlace { get; set; }

        [Required(ErrorMessage = "Munícipio é um campo obrigatório")]
        public string Number { get; set; }
        
        public Guid CityId { get; set; }
    }
}