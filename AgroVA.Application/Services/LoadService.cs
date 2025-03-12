using AgroVA.Application.DTOs;
using AgroVA.Application.Interfaces;
using AgroVA.Domain.Entities;
using AgroVA.Domain.Interfaces;
using AutoMapper;

namespace AgroVA.Application.Services
{
    public class LoadService : ServiceBase<LoadDTO, Load, ILoadRepository>, ILoadService
    {
        public LoadService(ILoadRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
