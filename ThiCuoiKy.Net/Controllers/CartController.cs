using Microsoft.AspNetCore.Mvc;
using ThiCuoiKy.Net.Models;
using ThiCuoiKy.Net.Models.ViewModels;
using ThiCuoiKy.Net.Repository;

namespace ThiCuoiKy.Net.Controllers
{
	public class CartController : Controller
	{
		private readonly DataContext _dataContext;

		public CartController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public IActionResult Index()
		{
			List<CartItemModel> cartItems = HttpContext.Session.GetJson<List<CartItemModel>>("Cart")  ?? new List<CartItemModel>();
			CartItemViewModel cartMV = new () { CartItems = cartItems, GrandTotal = cartItems.Sum(x => x.Quantity * x.Price) };
			return View(cartMV);
		}

		public ActionResult Checkout()
		{
			return View("~/Views/Checkout/Index.cshtml");
		}
	}

}
