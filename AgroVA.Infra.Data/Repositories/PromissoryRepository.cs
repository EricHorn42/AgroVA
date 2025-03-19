using AgroVA.Domain.Entities;
using AgroVA.Domain.Interfaces;
using AgroVA.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AgroVA.Infra.Data.Repositories
{
    public class PromissoryRepository : RepositoryBase<Promissory>, IPromissoryRepository
    {
        public PromissoryRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async override Task<IEnumerable<Promissory>> GetAllAsync()
        {
            return await _context.Set<Promissory>()
                .Include(f => f.Farmer)
                .Include(h => h.Harvest)
                .ToListAsync();
        }

        public virtual async Task<Promissory> GetByIdAsync(int? id)
        {
            return await _context.Set<Promissory>()
                .Include(f => f.Farmer)
                .Include(h => h.Harvest)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
    
}
