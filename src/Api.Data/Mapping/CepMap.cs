using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class CepMap : IEntityTypeConfiguration<Cep>
    {
        public void Configure(EntityTypeBuilder<Cep> builder)
        {
            builder.HasIndex(x => x.CEP);

            builder
                .HasOne(x => x.City)
                .WithMany(x => x.Ceps)
                .HasForeignKey(x => x.CityId);
        }

    }
}