using AutoMapper;
using FurnitureOnlineShop.Application.Contracts;
using FurnitureOnlineShop.Application.DTOs.Cart;
using MediatR;

namespace FurnitureOnlineShop.Application.Features.Cart.Query.GetCart;

public class GetCartRequestHandler : IRequestHandler<GetCartRequest, CartDto>
{
    private readonly IMapper _mapper;
    private readonly ICartRepository _cartRepository;

    public GetCartRequestHandler(IMapper mapper, ICartRepository cartRepository)
    {
        if (mapper is null)
        {
            throw new ArgumentNullException(nameof(mapper));
        }

        if (cartRepository is null)
        {
            throw new ArgumentNullException(nameof(cartRepository));
        }

        _mapper = mapper;
        _cartRepository = cartRepository;
    }


    public async Task<CartDto> Handle(GetCartRequest request, CancellationToken cancellationToken)
    {
        var cart = await _cartRepository.GetAsync(request.Id);
        var data = _mapper.Map<CartDto>(cart);
        return data;
    }
}
