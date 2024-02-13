using FurnitureOnlineShop.Application.Contracts;
using FurnitureOnlineShop.Application.Models;
using FurnitureOnlineShop.Infrastructure.EmailService;
using FurnitureOnlineShop.Infrastructure.LogService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FurnitureOnlineShop.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<EmailSetting>(configuration.GetSection("EmailSetting"));
        services.AddTransient<IEmailSender, EmailSender>();
        services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

        return services;
    }
}
