using FurnitureOnlineShop.Application.DTOs.Product;
using FurnitureOnlineShop.Domain.Entities;

namespace FurnitureOnlineShop.Application.Contracts;

public interface IProductRepository : IGenericRepository<Product>
{
  public Task<bool> isUniqueTitleAsync(string title);
  public Task<List<Product>> GetAllFavoriteProductsAsync();
}
