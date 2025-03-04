using AgroVA.Domain.Entities;
using AgroVA.Domain.Interfaces;
using AgroVA.Infra.Data.Context;

namespace AgroVA.Infra.Data.Repositories
{
    public class ReceiptRepository : RepositoryBase<Receipt>, IReceiptRepository
    {
        private readonly ApplicationDbContext _context;
        public ReceiptRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
    
}
