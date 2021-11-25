using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Id)
                .HasColumnType("CHAR(36)");

            builder.Property(x => x.Name)
                .HasColumnType("VARCHAR(60)");

            builder.Property(x => x.Email)
                .HasColumnType("VARCHAR(100)");
        }
    }
}