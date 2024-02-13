
using FurnitureOnlineShop.MVC.Contracts;
using FurnitureOnlineShop.MVC.Models.User;
using FurnitureOnlineShop.MVC.Services.Base;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using IAuthenticationService = FurnitureOnlineShop.MVC.Contracts.IAuthenticationService;

namespace FurnitureOnlineShop.MVC.Services
{
    public class AuthenticationService : BaseHttpService, IAuthenticationService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly JwtSecurityTokenHandler _jwtSecurityToken;
        public AuthenticationService(IClient client, ILocalStorageService localStorage, IHttpContextAccessor contextAccessor)
            : base(client, localStorage)
        {
            _contextAccessor = contextAccessor;
            _jwtSecurityToken = new JwtSecurityTokenHandler();
        }
        private IList<Claim> ParseClaims(JwtSecurityToken token)
        {
            var claims = token.Claims.ToList();
            claims.Add(new Claim(ClaimTypes.Name, token.Subject));
            return claims;
        }
        public async Task<bool> AuthenticateAsync(string username, string password)
        {
            try
            {
                AuthRequest authRequest = new()
                {
                    Username = username,
                    Password = password
                };
                AuthResponse authResponse = await _client.LoginAsync(authRequest);
                if (string.IsNullOrEmpty(authResponse.Token))
                {
                    return false;
                }
                var tokenContent = _jwtSecurityToken.ReadJwtToken(authResponse.Token);
                var claims = ParseClaims(tokenContent);
                var user = new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));
                var login = _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, user);
                _localStorage.SetStorageValue("token", authResponse.Token);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task Logout()
        {
            _localStorage.ClearStorage(new List<string>() { "token" });
            await _contextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public async Task<bool> RegisterAsync(RegisterVm user)
        {
            RegistrationRequest registrationRequest = new()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Password = user.Password
            };
            RegistrationResponse response = await _client.RegisterAsync(registrationRequest);
            if (string.IsNullOrEmpty(response.UserId))
            {
                return false;
            }
            return true;
        }
    }
}
