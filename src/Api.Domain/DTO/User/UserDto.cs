using System;

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

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}