using FurnitureOnlineShop.Application.DTOs.Product;
using FurnitureOnlineShop.Application.Features.Product.Query.GetAllProducts;
using MediatR;

namespace FurnitureOnlineShop.Application.Features.Product.Query.GetAllFavoriteProducts
{
    public record GetAllFavoriteProductsRequest : IRequest<List<ProductDto>>;
}