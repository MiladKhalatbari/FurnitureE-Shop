using FurnitureOnlineShop.Application.Contracts;
using FurnitureOnlineShop.Domain.Entities.Common;
using FurnitureOnlineShop.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace FurnitureOnlineShop.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    protected readonly FurnitureOnlineShopDBContext _context;

    public GenericRepository(FurnitureOnlineShopDBContext context)
    {
        _context = context;
    }
    public virtual async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync();
    }

    public virtual async Task<T> GetAsync(int id)
    {
        return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<int> AddAsync(T entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetAsync(id);
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistAsync(int id)
    {
        return await _context.Set<T>().AnyAsync(e=> e.Id == id);
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();
    }
}
