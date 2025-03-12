using AgroVA.Domain.Entities;
using AgroVA.Domain.Interfaces;
using AgroVA.Infra.Data.Context;

namespace AgroVA.Infra.Data.Repositories
{
    public class HarvestRepository : RepositoryBase<Harvest>, IHarvestRepository
    {
        public HarvestRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
