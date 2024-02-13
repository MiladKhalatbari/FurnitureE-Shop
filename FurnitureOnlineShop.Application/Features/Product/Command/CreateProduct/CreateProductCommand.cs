using FurnitureOnlineShop.Application.DTOs.Product;
using MediatR;

namespace FurnitureOnlineShop.Application.Features.Product.Command.CreateProduct;

public record CreateProductCommand(ProductCreateDto ProductCreate) : IRequest<int>;
