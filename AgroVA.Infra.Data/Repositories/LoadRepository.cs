using AgroVA.Domain.Entities;
using AgroVA.Domain.Interfaces;
using AgroVA.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AgroVA.Infra.Data.Repositories
{
    public class LoadRepository : RepositoryBase<Load>, ILoadRepository
    {
        public LoadRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async override Task<IEnumerable<Load>> GetAllAsync()
        {
            return await _context.Set<Load>()
                .Include(f => f.Farmer)
                .Include(h => h.Harvest)
                .ToListAsync();
        }

        public virtual async Task<Load> GetByIdAsync(int? id)
        {
            return await _context.Set<Load>()
                .Include(f => f.Farmer)
                .Include(h => h.Harvest)
                .FirstOrDefaultAsync(l => l.Id == id);
        }
    }
}
