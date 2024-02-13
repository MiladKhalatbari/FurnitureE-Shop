using AutoMapper;
using FurnitureOnlineShop.Application.Contracts;
using FurnitureOnlineShop.Application.DTOs.Product;
using FurnitureOnlineShop.Application.Features.Product.Command.CreateProduct;
using FurnitureOnlineShop.Application.MappingProfiles;
using FurnitureOnlineShop.Test.Mocks;
using Shouldly;

namespace FurnitureOnlineShop.Application.UnitTest.Features.Product.Command.CreateProduct;

public class CreateProductCommandHandlerTest
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public CreateProductCommandHandlerTest()
    {

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<ProductProfiles>();
        });
        _mapper = mapperConfig.CreateMapper();
        _productRepository = MockProductRepository.GetMockProductRepository().Object;
    }
    [Fact]
    public async Task Create_Product_ReturnProductId()
    {
        //Arange
        var handler = new CreateProductCommandHandler(_mapper, _productRepository);
        var productDto = new ProductCreateDto()
        {
            Description = "Test Desc",
            QuantityInStock = 1,
            ImagePath = "Test Path",
            Price = 12,
            Title = "TestUniqueeeeeTitle"
        };
        //Act
        var result = await handler.Handle(new CreateProductCommand(productDto), CancellationToken.None);
        //Assert
        result.ShouldBeOfType<int>();
    }
}
