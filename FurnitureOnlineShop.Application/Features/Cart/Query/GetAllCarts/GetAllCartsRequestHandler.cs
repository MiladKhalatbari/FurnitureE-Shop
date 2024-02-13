using AutoMapper;
using FurnitureOnlineShop.Application.Contracts;
using FurnitureOnlineShop.Application.DTOs.Cart;
using MediatR;

namespace FurnitureOnlineShop.Application.Features.Cart.Query.GetAllCarts;

public class GetAllCartsRequestHandler : IRequestHandler<GetAllCartsRequest, List<CartDto>>
{
    private readonly IMapper _mapper;
    private readonly ICartRepository _cartRepository;

    public GetAllCartsRequestHandler(IMapper mapper, ICartRepository cartRepository)
    {
        _mapper = mapper;
        _cartRepository = cartRepository;
    }
    public async Task<List<CartDto>> Handle(GetAllCartsRequest request, CancellationToken cancellationToken)
    {
        var carts =await _cartRepository.GetAllAsync();

        var data = _mapper.Map<List<CartDto>>(carts);

        return data;
    }
}
