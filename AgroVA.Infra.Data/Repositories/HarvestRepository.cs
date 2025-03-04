using AgroVA.Domain.Entities;
using AgroVA.Domain.Interfaces;
using AgroVA.Infra.Data.Context;

namespace AgroVA.Infra.Data.Repositories
{
    public class HarvestRepository : RepositoryBase<Harvest>, IHarvestRepository
    {
        private readonly ApplicationDbContext _context;
        public HarvestRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
