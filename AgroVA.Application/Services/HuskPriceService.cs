using AgroVA.Application.DTOs;
using AgroVA.Application.Interfaces;
using AgroVA.Domain.Entities;
using AgroVA.Domain.Interfaces;
using AutoMapper;

namespace AgroVA.Application.Services
{
    public class HuskPriceService : ServiceBase<HuskPriceDTO, HuskPrice, IHuskPriceRepository>, IHuskPriceService
    {
        public HuskPriceService(IHuskPriceRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
