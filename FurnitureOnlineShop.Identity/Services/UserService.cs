using FurnitureOnlineShop.Application.Contracts.Identity;
using FurnitureOnlineShop.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace FurnitureOnlineShop.Identity.Services
{
    public partial class AuthService
    {
        public class UserService : IUserService
        {
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly IHttpContextAccessor _httpContextAccessor;

            public UserService(UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
            {
                _userManager = userManager;
                _httpContextAccessor = httpContextAccessor;
            }

            public string UserId { get => _httpContextAccessor.HttpContext?.User.FindFirstValue("uid"); }

            public async Task<ApplicationUser> GetCustomer(string UserId)
            {
                return await _userManager.FindByIdAsync(UserId);
            }

            public async Task<List<ApplicationUser>> GetCustomers()
            {
                var customers = await _userManager.GetUsersInRoleAsync("Customer");
                return customers.ToList();
            }
        }
    }
}
