using FurnitureOnlineShop.Application.Models.Identity;

namespace FurnitureOnlineShop.Application.Contracts
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);

        Task<RegistrationResponse> Register(RegistrationRequest request);
    }
}
