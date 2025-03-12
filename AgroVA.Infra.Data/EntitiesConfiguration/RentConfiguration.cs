using AgroVA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgroVA.Infra.Data.EntitiesConfiguration
{
    public class RentConfiguration : IEntityTypeConfiguration<Rent>
    {
        public void Configure(EntityTypeBuilder<Rent> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Person)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(p => p.Percent)
                .IsRequired()
                .HasPrecision(3, 2);
            builder.Property(p => p.Value)
                .IsRequired()
                .HasPrecision(10, 2);
            builder.Property(p => p.Annotation)
                .HasMaxLength(500);

            builder.HasOne(fk => fk.Farmer)
                .WithMany()
                .HasForeignKey(fk => fk.FarmerId);
            builder.HasOne(fk => fk.Harvest)
                .WithMany()
                .HasForeignKey(fk => fk.HarvestId);
        }
    }
}
