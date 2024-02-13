using FurnitureOnlineShop.Application.Models;

namespace FurnitureOnlineShop.Application.Contracts;

public interface IEmailSender
{
    Task<bool> SendEmailAsync(EmailMessage email);
}
