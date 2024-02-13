using FurnitureOnlineShop.Application.DTOs.Cart;
using MediatR;

namespace FurnitureOnlineShop.Application.Features.Cart.Command.CreateCart;

public record CreateCartCommand(CartCreateDto CartCreateDto) : IRequest<int>;
