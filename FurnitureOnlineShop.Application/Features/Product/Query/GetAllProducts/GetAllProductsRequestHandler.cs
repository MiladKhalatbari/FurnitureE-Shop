using AutoMapper;
using FurnitureOnlineShop.Application.Contracts;
using FurnitureOnlineShop.Application.DTOs.Product;
using MediatR;

namespace FurnitureOnlineShop.Application.Features.Product.Query.GetAllProducts;

public class GetAllProductsRequestHandler : IRequestHandler<GetAllProductsRequest, List<ProductDto>>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public GetAllProductsRequestHandler(IMapper mapper, IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }
    public async Task<List<ProductDto>> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAllAsync();
        var data = _mapper.Map<List<ProductDto>>(products);
        return data;
    }
}
