using FurnitureOnlineShop.Application.DTOs.Product;
using MediatR;

namespace FurnitureOnlineShop.Application.Features.Product.Query.GetAllProducts;

public record GetAllProductsRequest : IRequest<List<ProductDto>>;
