using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class CityMap : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder
                .Property(x => x.Name)
                .HasColumnType("varchar(45)");

            builder.HasIndex(x => x.IbgeCode);

            builder
                .HasOne(x => x.State)
                .WithMany(x => x.Cities)
                .HasForeignKey(x => x.StateId);
        }
    }
}