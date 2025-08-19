using AgroVA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgroVA.Infra.Data.EntitiesConfiguration;

public class AnnotationConfiguration : IEntityTypeConfiguration<Annotation>
{
    public void Configure(EntityTypeBuilder<Annotation> builder)
    {
        builder.HasKey(k => k.Id);

        builder.Property(p => p.Observation)
             .IsRequired()
             .HasMaxLength(150);
        builder.Property(p => p.Timestamp)
            .IsRequired();

        builder.HasOne(p => p.Farmer)
            .WithMany(p => p.Annotations)
            .HasForeignKey(p => p.FarmerId);
        builder.HasOne(p => p.Harvest)
            .WithMany(p => p.Annotations)
            .HasForeignKey(p => p.HarvestId);
    }
}
