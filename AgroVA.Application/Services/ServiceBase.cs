using AgroVA.Application.DTOs;
using AgroVA.Application.Interfaces;
using AgroVA.Domain.Entities;
using AgroVA.Domain.Interfaces;
using AutoMapper;

namespace AgroVA.Application.Services;

public class ServiceBase<TEntityDto, TEntity, TRepository> : IServiceBase<TEntityDto>
    where TEntityDto : DTOBase
    where TEntity : EntityBase
    where TRepository : IRepositoryBase<TEntity>
{
    private readonly TRepository _repository;
    private readonly IMapper _mapper;

    public ServiceBase(TRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task AddAsync(TEntityDto entityDTO)
    {
        await _repository.AddAsync(_mapper.Map<TEntity>(entityDTO));

    }

    public async Task DeleteAsync(int? id)
    {
        await _repository.DeleteAsync(_repository.GetByIdAsync(id).Result);
    }

    public async Task<IEnumerable<TEntityDto>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();

        return _mapper.Map<IEnumerable<TEntityDto>>(entities);
    }

    public async Task<TEntityDto> GetByIdAsync(int? id)
    {
        var entitie = await _repository.GetByIdAsync(id);

        return _mapper.Map<TEntityDto>(entitie);
    }

    public async Task UpdateAsync(TEntityDto entityDTO)
    {
        await _repository.UpdateAsync(_mapper.Map<TEntity>(entityDTO));
    }
}
