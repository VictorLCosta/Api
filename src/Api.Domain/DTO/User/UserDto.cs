using System;
using System.ComponentModel.DataAnnotations;
using Api.Domain.Attributes;

namespace Api.Domain.DTO.User
{
    public class UserDto
    {
        public Guid Id { get; set; }

        private DateTime? _createdAt;
        public DateTime? CreatedAt
        {
            get { return _createdAt; }
            set { _createdAt = value == null ? DateTime.UtcNow : value; }
        }

        public DateTime? UpdatedAt { get; set; }

        [Required(ErrorMessage = "Por favor, informe o email")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Por favor, informe o email")]
        [EmailAddress(ErrorMessage = "Informe um email válido")]
        public string Email { get; set; }

        [Password(8, 20, true, true, true, false)]
        public string Password { get; set; }
    }
}