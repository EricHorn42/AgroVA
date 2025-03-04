using AgroVA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgroVA.Infra.Data.EntitiesConfiguration
{
    public class PromissoryConfiguration : IEntityTypeConfiguration<Promissory>
    {
        public void Configure(EntityTypeBuilder<Promissory> builder)
        {
            throw new NotImplementedException();
        }
    }
}
