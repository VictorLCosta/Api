using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class BaseEntity
    {
        private Guid _id;

        [Key]
        public Guid Id
        {
            get { return _id; }
            set { _id = value == Guid.Empty ? Guid.NewGuid() : value; }
        }

        private DateTime? _createdAt;
        public DateTime? CreatedAt
        {
            get { return _createdAt; }
            set { _createdAt = value == null ? DateTime.UtcNow : value; }
        }

        public DateTime? UpdatedAt { get; set; }
    }
}