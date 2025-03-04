using AgroVA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgroVA.Infra.Data.EntitiesConfiguration
{
    public class AnnotationConfiguration : IEntityTypeConfiguration<Annotation>
    {
        public void Configure(EntityTypeBuilder<Annotation> builder)
        {
            throw new NotImplementedException();
        }
    }
}
