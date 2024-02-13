using AutoMapper;
using FurnitureOnlineShop.Application.Contracts;
using FurnitureOnlineShop.Application.DTOs.Product;
using FurnitureOnlineShop.Application.Exceptions;
using MediatR;

namespace FurnitureOnlineShop.Application.Features.Product.Query.GetProduct;

public class GetProductRequestHandler : IRequestHandler<GetProductRequest, ProductDto>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public GetProductRequestHandler(IMapper mapper, IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }
    public async Task<ProductDto> Handle(GetProductRequest request, CancellationToken cancellationToken)
    {
        bool isExist = await _productRepository.ExistAsync(request.Id);

        if (!isExist)
            throw new NotFoundException("We Coudnt Find the Product,The ID was not Found");
        var product = await _productRepository.GetAsync(request.Id);
        var data = _mapper.Map<ProductDto>(product);
        return data;
    }
}
