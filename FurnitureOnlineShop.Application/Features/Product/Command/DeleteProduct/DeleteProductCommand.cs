using MediatR;

namespace FurnitureOnlineShop.Application.Features.Product.Command.DeleteProduct;

public record DeleteProductCommand(int Id) : IRequest<Unit>;
