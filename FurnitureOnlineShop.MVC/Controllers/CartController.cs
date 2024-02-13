using Microsoft.AspNetCore.Mvc;

namespace FurnitureOnlineShop.MVC.Controllers
{
	public class CartController : Controller
	{
		private readonly ILogger<CartController> _logger;

		public CartController(ILogger<CartController> logger)
		{
			_logger = logger;
		}
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Checkout()
		{
			return View();
		}
		public IActionResult ThankYou()
		{
			return View();
		}
	}
}
