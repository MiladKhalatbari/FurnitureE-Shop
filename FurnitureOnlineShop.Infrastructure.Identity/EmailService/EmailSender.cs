using FurnitureOnlineShop.Application.Contracts;
using FurnitureOnlineShop.Application.Models;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace FurnitureOnlineShop.Infrastructure.EmailService;

public class EmailSender : IEmailSender
{
    public EmailSetting EmailSetting { get; }
    public EmailSender(IOptions<EmailSetting> options)
    {
        EmailSetting = options.Value;
    }
    public async Task<bool> SendEmailAsync(EmailMessage email)
    {
        SendGridClient client = new SendGridClient(EmailSetting.ApiKey);
        var to = new EmailAddress(email.To);
        var from = new EmailAddress() { Email = EmailSetting.FromAddress, Name = EmailSetting.FromName };
        var message = MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body, email.Body);
        var response = await client.SendEmailAsync(message);
        return response.IsSuccessStatusCode;
    }
}
