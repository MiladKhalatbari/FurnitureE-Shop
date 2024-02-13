using AutoMapper;
using FurnitureOnlineShop.Application.Contracts;
using FurnitureOnlineShop.Application.DTOs.Product;
using FurnitureOnlineShop.Application.Features.Product.Query.GetAllProducts;
using FurnitureOnlineShop.Application.MappingProfiles;
using FurnitureOnlineShop.Test.Mocks;
using Moq;
using Shouldly;

namespace FurnitureOnlineShop.Application.UnitTest.Features.Product.Command.GetAllProducts;

public class GetAllProductsRequestHandlerTest
{
    private readonly IMapper _mapper;
    private IProductRepository _mockProductRepository;
    private Mock<IAppLogger<GetAllProductsRequestHandler>> _mockAppLogger;

    public GetAllProductsRequestHandlerTest()
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
    public async Task Get_Products_Test()
    {
        //Arange
        var handler = new GetAllProductsRequestHandler( _mapper , _mockProductRepository);
        //Act
        var result = await handler.Handle( new GetAllProductsRequest() , CancellationToken.None);
        //Assert
        result.ShouldBeOfType<List<ProductDto>>();
        result.Count.ShouldBe(3);
    }
}