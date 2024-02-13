using FurnitureOnlineShop.Application.DTOs.Product;
using MediatR;

namespace FurnitureOnlineShop.Application.Features.Product.Command.UpdateProduct;

public record UpdateProductCommand(ProductUpdateDto ProductUpdate) : IRequest<Unit>;
