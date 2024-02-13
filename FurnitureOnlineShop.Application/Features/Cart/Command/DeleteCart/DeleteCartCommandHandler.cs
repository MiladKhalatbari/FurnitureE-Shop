using AutoMapper;
using FurnitureOnlineShop.Application.Contracts;
using FurnitureOnlineShop.Application.Exceptions;
using MediatR;

namespace FurnitureOnlineShop.Application.Features.Cart.Command.DeleteCart;

public class DeleteCartCommandHandler : IRequestHandler<DeleteCartCommand, Unit>
{
    private readonly ICartRepository _cartRepository;
    private readonly IAppLogger<DeleteCartCommandHandler> _logger;

    public DeleteCartCommandHandler(ICartRepository cartRepository,IAppLogger<DeleteCartCommandHandler> logger)
    {
        _cartRepository = cartRepository;
        _logger = logger;
    }
    public async Task<Unit> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
    {
        bool IsExist = await _cartRepository.ExistAsync(request.Id);

        if (!IsExist)
        {
            _logger.LogError("NotFoundException in Delete request for {0} with ID {1}",nameof(Domain.Entities.Cart) ,request.Id);
            throw new NotFoundException("We Coudnt Delete the Cart,The ID was not Found");
        }
        await _cartRepository.DeleteAsync(request.Id);
        return Unit.Value;
    }
}
