using AgroVA.Domain.Entities;
using AgroVA.Domain.Interfaces;
using AgroVA.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AgroVA.Infra.Data.Repositories
{
    public class RentRepository : RepositoryBase<Rent>, IRentRepository
    {
        private readonly ApplicationDbContext _context;
        public RentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Rent> GetFarmerByIdAsync(int? id)
        {
            //eager loading
            return await _context.Rents.Include(f => f.Farmer).SingleOrDefaultAsync(r => r.Id == id);            
        }
    }
}
