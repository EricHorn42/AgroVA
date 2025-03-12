using AgroVA.Application.DTOs;
using AgroVA.Application.Interfaces;
using AgroVA.Domain.Entities;
using AgroVA.Domain.Interfaces;
using AutoMapper;

namespace AgroVA.Application.Services
{
    public class RentService : ServiceBase<RentDTO, Rent, IRentRepository>, IRentService
    {
        public RentService(IRentRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
