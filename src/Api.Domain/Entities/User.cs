using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        [NotMapped]
        public string ProvidedPassword { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}