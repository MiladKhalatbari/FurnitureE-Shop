using AutoMapper;
using FurnitureOnlineShop.Application.Contracts;
using FurnitureOnlineShop.Application.DTOs.Product.Validators;
using FurnitureOnlineShop.Application.Exceptions;
using MediatR;

namespace FurnitureOnlineShop.Application.Features.Product.Command.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public CreateProductCommandHandler(IMapper mapper, IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }
    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var validator = new ProductCreateDtoValidator(_productRepository);
        var ValidationResult = await validator.ValidateAsync(request.ProductCreate);
        if (!ValidationResult.IsValid)
            throw new BadRequestException("We Coudnt Create the Product,Invalid Data Exception", ValidationResult);

        var product = _mapper.Map<Domain.Entities.Product>(request.ProductCreate);
        await _productRepository.UpdateAsync(product);
        return product.Id;
    }
}
