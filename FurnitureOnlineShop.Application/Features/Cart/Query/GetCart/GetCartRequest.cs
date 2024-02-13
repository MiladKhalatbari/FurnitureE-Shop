using FurnitureOnlineShop.Application.DTOs.Cart;
using MediatR;

namespace FurnitureOnlineShop.Application.Features.Cart.Query.GetCart;

public record GetCartRequest(int Id):IRequest<CartDto>;
