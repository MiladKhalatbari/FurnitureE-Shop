using FurnitureOnlineShop.Application.DTOs.Cart;
using MediatR;

namespace FurnitureOnlineShop.Application.Features.Cart.Query.GetAllCarts;

public record GetAllCartsRequest:IRequest<List<CartDto>>;
