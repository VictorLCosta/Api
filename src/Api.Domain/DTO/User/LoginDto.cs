using System.ComponentModel.DataAnnotations;

namespace Api.Domain.DTO.User
{
    public class LoginDto
    {
        [EmailAddress(ErrorMessage = "Por favor, informe um email válido")]
        [Required(ErrorMessage = "Por favor, informe o seu email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor, informe a senha")]
        public string Password { get; set; }
    }
}