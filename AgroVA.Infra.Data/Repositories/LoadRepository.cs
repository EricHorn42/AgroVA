using AgroVA.Domain.Entities;
using AgroVA.Domain.Interfaces;
using AgroVA.Infra.Data.Context;

namespace AgroVA.Infra.Data.Repositories
{
    public class LoadRepository : RepositoryBase<Load>, ILoadRepository
    {
        public LoadRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
