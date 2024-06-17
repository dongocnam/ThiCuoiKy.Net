using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using ThiCuoiKy.Net.Models;
using ThiCuoiKy.Net.Repository;
using X.PagedList;

namespace ThiCuoiKy.Net.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _dataContext;

        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _dataContext = context;
        }

        public IActionResult Index(int? page)
        {
            int pageSize = 9;
            int pageNumber = page ?? 1;

            var products = _dataContext.Products
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .OrderByDescending(p => p.Id);

            // Create a paged list
            IPagedList<ProductModel> pagedProducts = products.ToPagedList(pageNumber, pageSize);

            // Pass paged list to the view
            return View(pagedProducts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int? statusCode)
        {
            if (statusCode.HasValue && statusCode.Value == 404)
            {
                return View("NotFound");
            }
            else
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        public IActionResult Search(string searchString, int? page)
        {
            var products = _dataContext.Products
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .OrderByDescending(p => p.Id) // Order by Id or any other criteria as needed
                .AsQueryable(); // Convert to IQueryable to enable dynamic querying

            // Apply search filter if searchString is provided
            if (!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(p =>
                    p.Name.Contains(searchString) ||
                    p.Description.Contains(searchString));
            }

            int pageSize = 10;
            int pageNumber = page ?? 1;

            // Create a paged list
            IPagedList<ProductModel> pagedProducts = products.ToPagedList(pageNumber, pageSize);

            // Pass paged list to the Index view
            return View("Index", pagedProducts);
        }
    }
}
