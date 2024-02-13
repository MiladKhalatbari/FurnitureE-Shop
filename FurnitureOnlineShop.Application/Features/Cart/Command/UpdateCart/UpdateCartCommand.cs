using FurnitureOnlineShop.Application.DTOs.Cart;
using MediatR;

namespace FurnitureOnlineShop.Application.Features.Cart.Command.UpdateCart;

public record UpdateCartCommand(CartUpdateDto CartUpdate) : IRequest<Unit>;
