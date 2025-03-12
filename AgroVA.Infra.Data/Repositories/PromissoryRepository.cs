using AgroVA.Domain.Entities;
using AgroVA.Domain.Interfaces;
using AgroVA.Infra.Data.Context;

namespace AgroVA.Infra.Data.Repositories
{
    public class PromissoryRepository : RepositoryBase<Promissory>, IPromissoryRepository
    {
        public PromissoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
    
}
