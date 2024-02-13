using AutoMapper;
using FurnitureOnlineShop.Application.Contracts;
using FurnitureOnlineShop.Application.Exceptions;
using MediatR;

namespace FurnitureOnlineShop.Application.Features.Cart.Command.UpdateCart;

public class UpdateCartCommandHandler : IRequestHandler<UpdateCartCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly ICartRepository _cartRepository;

    public UpdateCartCommandHandler(IMapper mapper, ICartRepository cartRepository)
    {
        _mapper = mapper;
        _cartRepository = cartRepository;
    }
    async Task<Unit> IRequestHandler<UpdateCartCommand, Unit>.Handle(UpdateCartCommand request, CancellationToken cancellationToken)
    {
        var cart = await _cartRepository.GetAsync(request.CartUpdate.Id);

        if (cart is null)
            throw new NotFoundException("We Coudnt Update the Cart,The ID was not Found");

        var newCart = _mapper.Map(request.CartUpdate, cart);
        await _cartRepository.UpdateAsync(newCart);
        return Unit.Value;
    }
}
