using AgroVA.Domain.Entities;
using AgroVA.Domain.Interfaces;
using AgroVA.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AgroVA.Infra.Data.Repositories
{
    public class AnnotationRepository : RepositoryBase<Annotation>, IAnnotationRepository
    {
        public AnnotationRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async override Task<IEnumerable<Annotation>> GetAllAsync()
        {
            return await _context.Set<Annotation>()
                .Include(f => f.Farmer)  
                .Include(h => h.Harvest)
                .ToListAsync();
        }

        public virtual async Task<Annotation> GetByIdAsync(int? id)
        {
            return await _context.Set<Annotation>()
                .Include(f => f.Farmer)
                .Include(h => h.Harvest)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

    }
}
