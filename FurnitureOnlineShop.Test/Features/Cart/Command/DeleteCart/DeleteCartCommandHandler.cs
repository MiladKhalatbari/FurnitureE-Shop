using FurnitureOnlineShop.Application.Contracts;
using FurnitureOnlineShop.Application.Exceptions;
using MediatR;

namespace FurnitureOnlineShop.Application.Features.Cart.Command.DeleteCart;

public class DeleteCartCommandHandler : IRequestHandler<DeleteCartCommand, Unit>
{
    private readonly ICartRepository _cartRepository;

    public DeleteCartCommandHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }
    public async Task<Unit> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
    {
        bool IsExist = await _cartRepository.ExistAsync(request.Id);

        if (!IsExist)
            throw new NotFoundException("We Coudnt Delete the Cart,The ID was not Found");

        await _cartRepository.DeleteAsync(request.Id);
        return Unit.Value;
    }
}
