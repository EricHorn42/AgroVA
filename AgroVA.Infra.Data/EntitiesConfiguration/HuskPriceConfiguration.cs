using AgroVA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgroVA.Infra.Data.EntitiesConfiguration
{
    public class HuskPriceConfiguration : IEntityTypeConfiguration<HuskPrice>
    {
        public void Configure(EntityTypeBuilder<HuskPrice> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Timestamp)
                .IsRequired();
            builder.Property(p => p.Price)
                .IsRequired()
                .HasPrecision(5, 2);
            builder.Property(p => p.Percent)
                .IsRequired()
                .HasPrecision(1, 2);

            builder.HasOne(fk => fk.Harvest)
                .WithMany(fk => fk.HuskPrices)
                .HasForeignKey(fk => fk.HarvestId);
        }
    }
}
