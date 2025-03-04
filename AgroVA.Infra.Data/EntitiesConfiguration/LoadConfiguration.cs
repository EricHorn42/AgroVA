using AgroVA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgroVA.Infra.Data.EntitiesConfiguration
{
    public class LoadConfiguration : IEntityTypeConfiguration<Load>
    {
        public void Configure(EntityTypeBuilder<Load> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Timestamp)
                .IsRequired();
            builder.Property(p => p.GreenWeight)
                .HasPrecision(5, 3);
            builder.Property(p => p.DryWeight)
                .HasPrecision(5, 3);
            builder.Property(p => p.Price)
                .HasPrecision(8, 2);
            builder.Property(p => p.Register)
                .IsRequired();
            builder.Property(p => p.Invoice)
                .IsRequired();

            builder.HasOne(fk => fk.Farmer)
                .WithMany(fk => fk.Loads)
                .HasForeignKey(fk => fk.FarmerId);
            builder.HasOne(fk => fk.Harvest)
                .WithMany(fk => fk.Loads)
                .HasForeignKey(fk => fk.HarvestId);
        }
    }
}
