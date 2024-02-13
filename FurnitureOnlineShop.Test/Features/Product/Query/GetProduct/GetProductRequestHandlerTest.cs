using AutoMapper;
using FurnitureOnlineShop.Application.Contracts;
using FurnitureOnlineShop.Application.DTOs.Product;
using FurnitureOnlineShop.Application.Features.Product.Query.GetAllProducts;
using FurnitureOnlineShop.Application.Features.Product.Query.GetProduct;
using FurnitureOnlineShop.Application.MappingProfiles;
using FurnitureOnlineShop.Test.Mocks;
using Moq;
using Shouldly;

namespace FurnitureOnlineShop.Application.UnitTest.Features.Product.Command.GetProduct;

public class GetProductRequestHandlerTest
{
    private readonly IMapper _mapper;
    private IProductRepository _mockProductRepository;
    private Mock<IAppLogger<GetAllProductsRequestHandler>> _mockAppLogger;

    public GetProductRequestHandlerTest()
    {

        _mockProductRepository = MockProductRepository.GetMockProductRepository().Object;

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<ProductProfiles>();

        });
        _mapper = mapperConfig.CreateMapper();
        _mockAppLogger = new Mock<IAppLogger<GetAllProductsRequestHandler>>();
    }
    [Fact]
    public async Task Get_Product_Test()
    {
        //Arange
        var handler = new GetProductRequestHandler(_mapper, _mockProductRepository);
        var existingProductId = 2;

        //Act
        var result = await handler.Handle(new GetProductRequest(existingProductId), CancellationToken.None);
        //Assert
        result.ShouldNotBeNull();
        result.ShouldBeOfType<ProductDto>();
        result.Id.ShouldBe(existingProductId);
    }
}
