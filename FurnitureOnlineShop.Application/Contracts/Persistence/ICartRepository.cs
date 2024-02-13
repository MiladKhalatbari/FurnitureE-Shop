using FurnitureOnlineShop.Domain.Entities;

namespace FurnitureOnlineShop.Application.Contracts;

public interface ICartRepository:IGenericRepository<Cart>
{
    public Task<Cart> GetOpenCartByUserIdAsync(string userId);

}
