using FurnitureOnlineShop.MVC.Models.User;

namespace FurnitureOnlineShop.MVC.Contracts
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateAsync(string Username, string password);
        Task<bool> RegisterAsync(RegisterVm registerVm);
        Task Logout();
    }
}
