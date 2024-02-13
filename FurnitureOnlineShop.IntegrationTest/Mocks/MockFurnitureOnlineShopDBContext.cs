using FurnitureOnlineShop.Domain.Entities;
using FurnitureOnlineShop.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Shouldly;

namespace FurnitureOnlineShop.IntegrationTest.Mocks;

public class MockFurnitureOnlineShopDBContext
{
    private FurnitureOnlineShopDBContext _context;

    public MockFurnitureOnlineShopDBContext()
    {
        var dbOptions = new DbContextOptionsBuilder<FurnitureOnlineShopDBContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
        _context = new FurnitureOnlineShopDBContext(dbOptions);
    }

    [Fact]
    public async Task SaveChange_AddProduct_SetDateCreatedValue()
    {
        //Arange
        var product = new Product
        {
            Id = 1,
            Description = "test",
            Title = "Test",
            ImagePath = "TestPath",
            Price = 1,
            QuantityInStock = 10,
        };
        var DatebeforeCreation = DateTime.Now;
        //Act
        await _context.AddAsync(product);
        await _context.SaveChangesAsync();
        var DateAfterCreation = DateTime.Now;

        //Assert
        product.CreatedDate.ShouldBeGreaterThan(DatebeforeCreation);
        product.CreatedDate.ShouldBeLessThan(DateAfterCreation);
    }
    [Fact]
    public async Task SaveChange_AddProduct_SetModifiedDateValue()
    {
        //Arange
        var product = new Product
        {
            Id = 1,
            Description = "test",
            Title = "Test",
            ImagePath = "TestPath",
            Price = 1,
            QuantityInStock = 10,
        };
        var DatebeforeCreation = DateTime.Now;
        //Act
        await _context.AddAsync(product);
        await _context.SaveChangesAsync();
        var DateAfterCreation = DateTime.Now;

        //Assert
        product.LastModifiedDate.ShouldBeGreaterThan(DatebeforeCreation);
        product.LastModifiedDate.ShouldBeLessThan(DateAfterCreation);
    }
   
}
