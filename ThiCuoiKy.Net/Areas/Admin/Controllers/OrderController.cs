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
            if (string.IsNullOrEmpty(ordercode))
            {
                return NotFound();
            }

            var orderDetails = await _dataContext.OrderDetail
                                                 .Include(od => od.Product)
                                                 .Where(od => od.OrderCode == ordercode)
                                                 .ToListAsync();

            if (orderDetails == null || !orderDetails.Any())
            {
                return NotFound();
            }

            return View(orderDetails);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteOrder(string ordercode)
        {
            if (string.IsNullOrEmpty(ordercode))
            {
                return NotFound();
            }

            var order = await _dataContext.Orders
                                          .FirstOrDefaultAsync(o => o.OrderCode == ordercode);

            if (order == null)
            {
                return NotFound();
            }

            var orderDetails = await _dataContext.OrderDetail
                                                 .Where(od => od.OrderCode == ordercode)
                                                 .ToListAsync();

            _dataContext.OrderDetail.RemoveRange(orderDetails);
            _dataContext.Orders.Remove(order);
            await _dataContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
