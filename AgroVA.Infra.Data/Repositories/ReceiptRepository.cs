using AgroVA.Domain.Entities;
using AgroVA.Domain.Interfaces;
using AgroVA.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AgroVA.Infra.Data.Repositories
{
    public class ReceiptRepository : RepositoryBase<Receipt>, IReceiptRepository
    {
        public ReceiptRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async override Task<IEnumerable<Receipt>> GetAllAsync()
        {
            return await _context.Set<Receipt>()
                .Include(f => f.Farmer)
                .Include(h => h.Harvest)
                .ToListAsync();
        }

        public async override Task<Receipt> GetByIdAsync(int? id)
        {
            return await _context.Set<Receipt>()
                .Include(f => f.Farmer)
                .Include(h => h.Harvest)
                .FirstOrDefaultAsync(r => r.Id == id);
        }
    }
    
}
