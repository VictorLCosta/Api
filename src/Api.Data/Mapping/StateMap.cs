using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class StateMap : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder
                .Property(x => x.Name)
                .HasColumnType("varchar(45)");

            builder
                .Property(x => x.UF)
                .HasColumnType("char(2)");

            builder
                .HasIndex(x => x.UF)
                .IsUnique();
        }
    }
}