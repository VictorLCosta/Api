using System;
using System.ComponentModel.DataAnnotations;

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

        [Required(ErrorMessage = "Por favor, informe a senha")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Por favor, a senha deve ter entre 8 e 20 caracteres")]
        public string Password { get; set; }
    }
}