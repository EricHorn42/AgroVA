using AgroVA.Domain.Entities;
using AgroVA.Domain.Interfaces;
using AgroVA.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AgroVA.Infra.Data.Repositories
{
    public class RentRepository : RepositoryBase<Rent>, IRentRepository
    {
        public RentRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async override Task<IEnumerable<Rent>> GetAllAsync()
        {
            return await _context.Set<Rent>()
                .Include(f => f.Farmer)
                .Include(h => h.Harvest)
                .ToListAsync();
        }

        public async override Task<Rent> GetByIdAsync(int? id)
        {
            return await _context.Set<Rent>()
                .Include(f => f.Farmer)
                .Include(h => h.Harvest)
                .FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
