using FurnitureOnlineShop.MVC.Contracts;
using FurnitureOnlineShop.MVC.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureOnlineShop.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public AccountController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        // GET: AccountController1/Login
        public ActionResult Login(string? returnUrl = null)
        {
            return View();
        }
        // POST: AccountController1/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginVm user, string returnUrl)
        {
            returnUrl ??= Url.Content("~/");
            try
            {
                var isLoggedIn = await _authenticationService.AuthenticateAsync(user.UserName, user.Password);
                if (isLoggedIn)
                {
                    return Redirect(returnUrl);
                }
                ModelState.AddModelError("", "Login Failed,Please Try again.");
                return View(user);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(user);
            }
        }

        // POST: AccountController1/Logout
        [HttpPost]
        public async Task<ActionResult> Logout()
        {
            await _authenticationService.Logout();
            return View("Login");
        }
        // GET: AccountController1/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: AccountController1/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterVm user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(user);
                }
                var isSuccess = await _authenticationService.RegisterAsync(user);
                if (isSuccess)
                {
                    return Redirect("/");
                }
                ModelState.AddModelError("", "Register Failed,Please Try again.");
                return View(user);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(user);
            }
        }
    }
}
