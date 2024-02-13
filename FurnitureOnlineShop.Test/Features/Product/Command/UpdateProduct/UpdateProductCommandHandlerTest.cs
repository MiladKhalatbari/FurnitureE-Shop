using AutoMapper;
using FurnitureOnlineShop.Application.Contracts;
using FurnitureOnlineShop.Application.DTOs.Product;
using FurnitureOnlineShop.Application.Features.Product.Command.UpdateProduct;
using FurnitureOnlineShop.Application.Features.Product.Query.GetAllProducts;
using FurnitureOnlineShop.Application.MappingProfiles;
using FurnitureOnlineShop.Test.Mocks;
using MediatR;
using Moq;
using Shouldly;

namespace FurnitureOnlineShop.Application.UnitTest.Features.Product.Command.UpdateProduct;

public class UpdateProductCommandHandlerTest
{
    private readonly IMapper _mapper;
    private IProductRepository _mockProductRepository;
    private Mock<IAppLogger<GetAllProductsRequestHandler>> _mockAppLogger;

    public UpdateProductCommandHandlerTest()
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
    public async Task Update_Product_Test()
    {
        //Arange
        var handler = new UpdateProductCommandHandler(_mapper, _mockProductRepository);
        var existingProductid = 2;
        ProductUpdateDto existingupdateDto = new()
        {
            Id = existingProductid,
            Description = "updatedtestDesc",
            ImagePath = "updatedtestPath",
            Price = 12,
            QuantityInStock = 100
        };
        //Act
        var result = await handler.Handle(new UpdateProductCommand(existingupdateDto), CancellationToken.None);
        //Assert
        result.ShouldBe(Unit.Value);
    }
}