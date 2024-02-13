using AutoMapper;
using FurnitureOnlineShop.Application.Contracts;
using MediatR;

namespace FurnitureOnlineShop.Application.Features.Cart.Command.CreateCart;

public class CreateCartCommandHandler : IRequestHandler<CreateCartCommand, int>
{
    private readonly IMapper _mapper;
    private readonly ICartRepository _cartRepository;

    public CreateCartCommandHandler(IMapper mapper, ICartRepository cartRepository)
    {
        _mapper = mapper;
        _cartRepository = cartRepository;
    }
    public async Task<int> Handle(CreateCartCommand request, CancellationToken cancellationToken)
    {
        var cart = _mapper.Map<Domain.Entities.Cart>(request.CartCreateDto);
        await _cartRepository.UpdateAsync(cart);
        return cart.Id;
    }
}
