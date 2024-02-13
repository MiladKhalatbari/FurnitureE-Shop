using AutoMapper;
using FurnitureOnlineShop.Application.Contracts;
using FurnitureOnlineShop.Application.DTOs.Product;
using MediatR;

namespace FurnitureOnlineShop.Application.Features.Product.Query.GetAllFavoriteProducts
{
    public class GetAllFavoriteProductsHandler : IRequestHandler<GetAllFavoriteProductsRequest, List<ProductDto>>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public GetAllFavoriteProductsHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public async Task<List<ProductDto>> Handle(GetAllFavoriteProductsRequest request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllFavoriteProductsAsync();
            var data = _mapper.Map<List<ProductDto>>(products);
            return data;
        }
    }
}