using FurnitureOnlineShop.Application.DTOs.Cart;
using MediatR;

namespace FurnitureOnlineShop.Application.Features.Cart.Command.DeleteCart;

public record DeleteCartCommand(int Id) : IRequest<Unit>;
