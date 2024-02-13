using FurnitureOnlineShop.Application.Contracts;
using FurnitureOnlineShop.Persistence.Context;
using FurnitureOnlineShop.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FurnitureOnlineShop.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceService(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<FurnitureOnlineShopDBContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("FurnitureOnlineShopConnectionString"));
        });
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<ICartRepository, CartRepository>();

        return services;
    }
}
