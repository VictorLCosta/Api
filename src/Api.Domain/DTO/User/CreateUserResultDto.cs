using System;

namespace Api.Domain.DTO.User
{
    public class CreateUserResultDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}