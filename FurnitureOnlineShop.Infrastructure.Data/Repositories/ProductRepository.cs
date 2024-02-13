using FurnitureOnlineShop.Application.Contracts;
using FurnitureOnlineShop.Application.DTOs.Product;
using FurnitureOnlineShop.Domain.Entities;
using FurnitureOnlineShop.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace FurnitureOnlineShop.Persistence.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(FurnitureOnlineShopDBContext context) : base(context)
    {

    }

    public  Task<List<Product>> GetAllFavoriteProductsAsync()
    {
        return _context.CartItems
            .GroupBy(ci => ci.Product)
            .Select(g => new
            {
                Product = g.Key,
                TotalQuantitySold = g.Sum(ci => ci.Quantity)
            })
            .OrderByDescending(p => p.TotalQuantitySold).Select(s => s.Product)
            .Take(3)
            .ToListAsync();
    }

    public async Task<bool> isUniqueTitleAsync(string title)
    {
        return await _context.Products.AnyAsync(p => p.Title.ToLower() == title.ToLower()) == false;
    }
}