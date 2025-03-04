using AgroVA.Domain.Entities;
using AgroVA.Domain.Interfaces;
using AgroVA.Infra.Data.Context;

namespace AgroVA.Infra.Data.Repositories
{
    public class AnnotationRepository : RepositoryBase<Annotation>, IAnnotationRepository
    {
        private readonly ApplicationDbContext _context;
        public AnnotationRepository(ApplicationDbContext context) : base(context)
        {            
            _context = context;
        }

    }
}
