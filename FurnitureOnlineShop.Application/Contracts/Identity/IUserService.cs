using FurnitureOnlineShop.Domain.Entities;

namespace FurnitureOnlineShop.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<List<ApplicationUser>> GetCustomers();

        Task<ApplicationUser> GetCustomer(string UserId);

        public string UserId { get; }
    }
}
