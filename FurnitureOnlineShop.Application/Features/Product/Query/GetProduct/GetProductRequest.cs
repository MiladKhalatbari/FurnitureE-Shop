using FurnitureOnlineShop.Application.DTOs.Product;
using MediatR;

namespace FurnitureOnlineShop.Application.Features.Product.Query.GetProduct;

public record GetProductRequest(int Id) : IRequest<ProductDto>;
