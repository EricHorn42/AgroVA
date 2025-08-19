using AgroVA.Application.DTOs;

namespace AgroVA.Application.Interfaces;

public interface IServiceBase<TEntityDto>
    where TEntityDto : DTOBase
{
    Task AddAsync(TEntityDto entityDTO);
    Task UpdateAsync(TEntityDto entityDTO);
    Task DeleteAsync(int? id);

    Task<TEntityDto> GetByIdAsync(int? id);
    Task<IEnumerable<TEntityDto>> GetAllAsync();
}