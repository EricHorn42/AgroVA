using AgroVA.Application.DTOs;
using AgroVA.Application.Interfaces;
using AgroVA.Domain.Entities;
using AgroVA.Domain.Interfaces;
using AutoMapper;

namespace AgroVA.Application.Services;

public class PromissoryService : ServiceBase<PromissoryDTO, Promissory, IPromissoryRepository>, IPromissoryService
{
    public PromissoryService(IPromissoryRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
