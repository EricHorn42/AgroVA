using AgroVA.Domain.Entities;
using AgroVA.Domain.Interfaces;
using AgroVA.Infra.Data.Context;

namespace AgroVA.Infra.Data.Repositories
{
    public class LoadRepository : RepositoryBase<Load>, ILoadRepository
    {
        private readonly ApplicationDbContext _context;
        public LoadRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
