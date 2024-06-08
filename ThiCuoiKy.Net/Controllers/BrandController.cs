using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThiCuoiKy.Net.Models;
using ThiCuoiKy.Net.Repository;

namespace ThiCuoiKy.Net.Controllers
{
	public class BrandController : Controller
	{
		private readonly DataContext _dataContext;
		public BrandController(DataContext context)
		{
			_dataContext = context;
		}

		public async Task<IActionResult> Index(string Slug = "")
		{
			BrandModel brand = _dataContext.Brands.Where(c => c.Slug == Slug).FirstOrDefault();
			if (brand == null)
				return RedirectToAction("Index");
			var productsByBrand = _dataContext.Products.Where(p => p.BrandID == brand.Id);
			return View(await productsByBrand.OrderByDescending(c => c.Id).ToListAsync());
		}
	}
}
