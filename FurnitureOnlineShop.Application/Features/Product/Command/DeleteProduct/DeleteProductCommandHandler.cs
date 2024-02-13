using FurnitureOnlineShop.Application.Contracts;
using FurnitureOnlineShop.Application.Exceptions;
using MediatR;

namespace FurnitureOnlineShop.Application.Features.Product.Command.DeleteProduct;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
{
    private readonly IProductRepository _productRepository;

    public DeleteProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        bool isExist = await _productRepository.ExistAsync(request.Id);
        if (!isExist)
            throw new NotFoundException("We Coudnt Delete the Product,The ID was not Found");

        await _productRepository.DeleteAsync(request.Id);
        return Unit.Value;
    }
}
