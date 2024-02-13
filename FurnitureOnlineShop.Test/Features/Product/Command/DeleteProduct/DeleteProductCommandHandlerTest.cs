using FurnitureOnlineShop.Application.Contracts;
using FurnitureOnlineShop.Application.Features.Product.Command.DeleteProduct;
using FurnitureOnlineShop.Test.Mocks;
using MediatR;
using Shouldly;

namespace FurnitureOnlineShop.Application.UnitTest.Features.Product.Command.DeleteProduct;

public class DeleteProductCommandHandlerTest
{
    private IProductRepository _mockProductRepository;

    public DeleteProductCommandHandlerTest()
    {
        _mockProductRepository = MockProductRepository.GetMockProductRepository().Object;
    }
    [Fact]
    public async Task Delete_Product_Test()
    {
        //Arange
        var handler = new DeleteProductCommandHandler(_mockProductRepository);
        var existingProductId = 2;
        //Act
        var result = await handler.Handle(new DeleteProductCommand(existingProductId), CancellationToken.None);
        //Assert
        result.ShouldBe(Unit.Value);
    }
}

