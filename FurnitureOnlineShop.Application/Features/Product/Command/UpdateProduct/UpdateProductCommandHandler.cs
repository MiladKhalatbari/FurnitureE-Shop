using AutoMapper;
using FurnitureOnlineShop.Application.Contracts;
using FurnitureOnlineShop.Application.DTOs.Product.Validators;
using FurnitureOnlineShop.Application.Exceptions;
using MediatR;

namespace FurnitureOnlineShop.Application.Features.Product.Command.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public UpdateProductCommandHandler(IMapper mapper, IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }
    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetAsync(request.ProductUpdate.Id);
        if (product is null)
            throw new NotFoundException("We Coudnt Update the Product,The ID was not Found");

        var validator = new ProductUpdateDtoValidator();
        var ValidationResult = await validator.ValidateAsync(request.ProductUpdate);
        if (!ValidationResult.IsValid)
            throw new BadRequestException("We Coudnt Update the Product Invald Data Exception", ValidationResult);

        var newProduct = _mapper.Map(request.ProductUpdate,product);
        await _productRepository.UpdateAsync(newProduct);
        return Unit.Value;
    }
}
