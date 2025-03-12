using AgroVA.Application.DTOs;
using AgroVA.Application.Interfaces;
using AgroVA.Domain.Entities;
using AgroVA.Domain.Interfaces;
using AutoMapper;

namespace AgroVA.Application.Services
{
    public class HarvestService : ServiceBase<HarvestDTO, Harvest, IHarvestRepository>, IHarvestService
    {
        public HarvestService(IHarvestRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
