using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroVA.Domain.Interfaces;

public interface IRepositoryBase<TEntity> 
    where TEntity : class
{
    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<TEntity> DeleteAsync(TEntity entity);

    Task<TEntity> GetByIdAsync(int? id);
    Task<IEnumerable<TEntity>> GetAllAsync();
}
