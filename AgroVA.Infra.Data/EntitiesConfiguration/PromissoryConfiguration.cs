using AgroVA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgroVA.Infra.Data.EntitiesConfiguration
{
    public class PromissoryConfiguration : IEntityTypeConfiguration<Promissory>
    {
        public void Configure(EntityTypeBuilder<Promissory> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Timestamp)
                .IsRequired();
            builder.Property(p => p.Value)
                .IsRequired();

            builder.HasOne(fk => fk.Farmer)
                .WithMany(fk => fk.Promissories)
                .HasForeignKey(fk => fk.FarmerId);
            builder.HasOne(fk => fk.Harvest)
                .WithMany(fk => fk.Promissories)
                .HasForeignKey(fk => fk.HarvestId);
        }
    }
}
