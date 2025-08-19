using AgroVA.Domain.Entities;
using AgroVA.Domain.Interfaces;
using AgroVA.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AgroVA.Infra.Data.Repositories;

public class HuskPriceRepository : RepositoryBase<HuskPrice>, IHuskPriceRepository
{
    public HuskPriceRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async override Task<IEnumerable<HuskPrice>?> GetAllAsync()
    {
        return await _context.Set<HuskPrice>()
            .Include(h => h.Harvest)
            .ToListAsync();
    }

    public override async Task<HuskPrice?> GetByIdAsync(int? id)
    {
        return await _context.Set<HuskPrice>()
            .Include(h => h.Harvest)
            .FirstOrDefaultAsync(h => h.Id == id);
    }
}
