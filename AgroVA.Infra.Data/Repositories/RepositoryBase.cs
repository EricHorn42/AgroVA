using AgroVA.Domain.Entities;
using AgroVA.Domain.Interfaces;
using AgroVA.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AgroVA.Infra.Data.Repositories;

public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> 
    where TEntity : EntityBase
{
    protected readonly ApplicationDbContext _context;
    
    public RepositoryBase(ApplicationDbContext context)
    {
        _context = context;
    }

    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<TEntity> DeleteAsync(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<TEntity> UpdateAsync(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    public virtual async Task<TEntity> GetByIdAsync(int? id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }
}
