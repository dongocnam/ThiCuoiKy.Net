using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThiCuoiKy.Net.Repository;

namespace ThiCuoiKy.Net.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class OrderController : Controller
    {
        private readonly DataContext _dataContext;
        public OrderController(DataContext context)
        {
            _dataContext = context;

        }
        public async Task<IActionResult> Index()
        {
            var categories = await _dataContext.Orders
                                               .OrderByDescending(c => c.Id)
                                               .ToListAsync();
            return View(categories);
        }
        public async Task<IActionResult> ViewOrder(string ordercode)
        {
            var DetailsOrder = await _dataContext.OrderDetail.Include(od => od.Product).Where(od=>od.OrderCode==ordercode).ToListAsync();
            return View(DetailsOrder);                           

        }

    }
}
