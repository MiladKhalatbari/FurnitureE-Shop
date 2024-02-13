using FurnitureOnlineShop.Application.Contracts;
using FurnitureOnlineShop.Domain.Entities;
using Moq;

namespace FurnitureOnlineShop.Test.Mocks;

public class MockProductRepository
{
    public static Mock<IProductRepository> GetMockProductRepository()
    {
        var products = new List<Product>
            {
                new Product {
                    Id = 1,
                    Description = "test",
                    Title = "Test",
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now,
                    ImagePath = "TestPath",
                    Price = 1,
                    QuantityInStock = 10,
                },
                new Product {
                    Id = 2,
                    Description = "test",
                    Title = "Test",
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now,
                    ImagePath = "TestPath",
                    Price = 1,
                    QuantityInStock = 10,
                },
                new Product {
                    Id = 3,
                    Description = "test",
                    Title = "Test",
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now,
                    ImagePath = "TestPath",
                    Price = 1,
                    QuantityInStock = 10,
                }
            };

        var mockRepo = new Mock<IProductRepository>();
        mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(products);


        mockRepo.Setup(repo => repo.AddAsync(It.IsAny<Product>())).
            ReturnsAsync((Product product) =>
            {
                product.Id = products.Count + 1;
                products.Add(product);
                return product.Id;
            });

      

        mockRepo.Setup(repo => repo.ExistAsync(It.IsAny<int>()))
            .ReturnsAsync((int id) => products.Exists(p => p.Id == id));



        mockRepo.Setup(repo => repo.GetAsync(It.IsAny<int>()))
            .ReturnsAsync((int id) => products.Find(p => p.Id == id));

        mockRepo.Setup(repo => repo.isUniqueTitleAsync(It.IsAny<string>()))
            .ReturnsAsync((string title) => !products.Exists(p => p.Title == title));

        mockRepo.Setup(repo => repo.UpdateAsync(It.IsAny<Product>()))
       .Callback<Product>(async (updatedProduct) =>
       {
           var existingProduct = products.Find(p => p.Id == updatedProduct.Id);
           existingProduct.Title = updatedProduct.Title;
           existingProduct.Description = updatedProduct.Description;
           existingProduct.Price = updatedProduct.Price;
           existingProduct.QuantityInStock = updatedProduct.QuantityInStock;
           existingProduct.ImagePath = updatedProduct.ImagePath;
           existingProduct.LastModifiedDate = DateTime.Now;

           await Task.CompletedTask;
       });

        mockRepo.Setup(repo => repo.DeleteAsync(It.IsAny<int>()))
            .Callback<int>(async (id) =>
            {
                var product = products.Find(p => p.Id == id);
                products.Remove(product);

                await Task.CompletedTask; 
            });

        return mockRepo;
    }
}

