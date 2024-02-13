using FurnitureOnlineShop.Application.Contracts;
using FurnitureOnlineShop.Domain.Entities;
using FurnitureOnlineShop.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace FurnitureOnlineShop.Persistence.Repositories;

public class CartRepository : GenericRepository<Cart>, ICartRepository
{
    public CartRepository(FurnitureOnlineShopDBContext context) : base(context) { }

    public async Task<Cart?> GetOpenCartByUserIdAsync(string userId)
    {
        return await _context.Carts.Include(c=> c.cartItems).FirstOrDefaultAsync(c=> c.IdentityUserId.Equals(userId) && !c.IsFinaly);
    }


}
