using AgroVA.Domain.Entities;
using AgroVA.Domain.Interfaces;
using AgroVA.Infra.Data.Context;

namespace AgroVA.Infra.Data.Repositories
{
    public class HuskPriceRepository : RepositoryBase<HuskPrice>, IHuskPriceRepository
    {
        public HuskPriceRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
