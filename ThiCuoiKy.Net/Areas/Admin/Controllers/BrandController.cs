using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using ThiCuoiKy.Net.Models;
using ThiCuoiKy.Net.Repository;

namespace ThiCuoiKy.Net.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BrandController(DataContext context, IWebHostEnvironment webHostEnvironment)
        {
            _dataContext = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var brands = await _dataContext.Brands.OrderByDescending(b => b.Id).ToListAsync();
            return View(brands);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BrandModel brand)
        {
            if (ModelState.IsValid)
            {
                brand.Slug = brand.Name.Replace(" ", "-").ToLower();
                var existingBrand = await _dataContext.Brands.FirstOrDefaultAsync(b => b.Slug == brand.Slug);

                if (existingBrand != null)
                {
                    ModelState.AddModelError("", "Dòng sản phẩm đã tồn tại trong cơ sở dữ liệu");
                    return View(brand);
                }

                _dataContext.Add(brand);
                await _dataContext.SaveChangesAsync();
                TempData["success"] = "Thêm thương hiệu thành công";
                return RedirectToAction(nameof(Index));
            }

            TempData["error"] = "Tạo thương hiệu không thành công";
            return View(brand);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var brand = await _dataContext.Brands.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }

            return View(brand);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BrandModel brand)
        {
            if (id != brand.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingBrand = await _dataContext.Brands.FirstOrDefaultAsync(b => b.Id == id);
                    if (existingBrand == null)
                    {
                        return NotFound();
                    }

                    existingBrand.Name = brand.Name;
                    existingBrand.Description = brand.Description;
                    existingBrand.Slug = brand.Name.Replace(" ", "-").ToLower();
                    existingBrand.Status = brand.Status;

                    _dataContext.Update(existingBrand);
                    await _dataContext.SaveChangesAsync();
                    TempData["success"] = "Cập nhật thương hiệu thành công";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrandExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            TempData["error"] = "Cập nhật thương hiệu không thành công";
            return View(brand);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brand = await _dataContext.Brands.FirstOrDefaultAsync(b => b.Id == id);
            if (brand == null)
            {
                return NotFound();
            }

            return View(brand);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var brand = await _dataContext.Brands.FindAsync(id);
            if (brand != null)
            {
                _dataContext.Brands.Remove(brand);
                await _dataContext.SaveChangesAsync();
                TempData["success"] = "Xóa thương hiệu thành công";
            }
            else
            {
                TempData["error"] = "Thương hiệu không tồn tại";
            }
            return RedirectToAction(nameof(Index));
        }

        private bool BrandExists(int id)
        {
            return _dataContext.Brands.Any(b => b.Id == id);
        }
    }
}
