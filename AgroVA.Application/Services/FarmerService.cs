using AgroVA.Application.DTOs;
using AgroVA.Application.Interfaces;
using AgroVA.Domain.Entities;
using AgroVA.Domain.Interfaces;
using AutoMapper;

namespace AgroVA.Application.Services
{
    public class FarmerService : ServiceBase<FarmerDTO, Farmer, IFarmerRepository>, IFarmerService
    {
        public FarmerService(IFarmerRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
