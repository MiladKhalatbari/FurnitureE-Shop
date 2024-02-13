using FurnitureOnlineShop.Domain.Entities.Common;

namespace FurnitureOnlineShop.Application.Contracts;

public interface IGenericRepository<T> where T : BaseEntity
{
    public Task<T> GetAsync(int id);
    public Task<IReadOnlyList<T>> GetAllAsync();
    public Task<bool> ExistAsync(int id);
    public Task<int> AddAsync(T item);
    public Task UpdateAsync(T entity);
    public Task DeleteAsync(int id);

}

