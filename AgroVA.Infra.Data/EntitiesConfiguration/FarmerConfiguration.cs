using AgroVA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgroVA.Infra.Data.EntitiesConfiguration;

public class FarmerConfiguration : IEntityTypeConfiguration<Farmer>
{
    public void Configure(EntityTypeBuilder<Farmer> builder)
    {
        builder.HasKey(k => k.Id);

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(150);
        builder.Property(p => p.Phone)
            .IsRequired()
            .HasMaxLength(13);
    }
}
