using AgroVA.Domain.Entities;
using AgroVA.Domain.Interfaces;
using AgroVA.Infra.Data.Context;

namespace AgroVA.Infra.Data.Repositories;

public class FarmerRepository : RepositoryBase<Farmer>, IFarmerRepository
{
    public FarmerRepository(ApplicationDbContext context) : base(context)
    {
    }
}
