using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.DTO.City
{
    public class UpdateCityDto
    {
        [Required(ErrorMessage = "Id é um campo obrigatório")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do munícipio")]
        [StringLength(60, ErrorMessage = "O nome do munícipio deve ter no máximo {1} caracteres")]
        public string Name { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "O código do IBGE está inválido")]
        public int IbgeCode { get; set; }

        [Required(ErrorMessage = "Informe o campo do código UF")]
        public Guid StateId { get; set; }
    }
}