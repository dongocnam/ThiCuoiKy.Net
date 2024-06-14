using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ThiCuoiKy.Net.Models;
using ThiCuoiKy.Net.Repository;

namespace ThiCuoiKy.Net.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CategoryController(DataContext context)
        {
            _dataContext = context;
           
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _dataContext.Categories
                                               .OrderByDescending(c => c.Id)
                                               .ToListAsync();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryModel category)
        {
            if (ModelState.IsValid)
            {

                category.Slug = category.Name.Replace(" ", "-").ToLower(); ;
                var slug = await _dataContext.Categories.FirstOrDefaultAsync(c => c.Slug == category.Slug);

                if (slug != null)
                {
                    ModelState.AddModelError("", "Danh mục đã tồn tại trong cơ sở dữ liệu");
                    return View(category);
                }
              
                    _dataContext.Add(category);
                    await _dataContext.SaveChangesAsync();
                    TempData["success"] = "Thêm danh mục thành công";
                    return RedirectToAction("Index");
                
            }

            TempData["error"] = "Tạo danh mục không thành công";
            List<string> errors = new List<string>();
            foreach (var value in ModelState.Values) 
            {
                foreach
                    (var error in value.Errors)
                {
                    errors.Add(error.ErrorMessage);
                }
            }
            string errorMessage = string.Join("\n ", errors);
            return View(category);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var category = await _dataContext.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CategoryModel category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Update the slug if the name changes
                    var existingCategory = await _dataContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
                    if (existingCategory == null)
                    {
                        return NotFound();
                    }

                    existingCategory.Name = category.Name;
                    existingCategory.Description = category.Description;
                    existingCategory.Slug = category.Name.Replace(" ", "-").ToLower(); // Update the slug if name changes

                    _dataContext.Update(existingCategory);
                    await _dataContext.SaveChangesAsync();
                    TempData["success"] = "Cập nhật danh mục thành công";
                    return RedirectToAction("Index");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            TempData["error"] = "Cập nhật danh mục không thành công";
            List<string> errors = new List<string>();
            foreach (var value in ModelState.Values)
            {
                foreach (var error in value.Errors)
                {
                    errors.Add(error.ErrorMessage);
                }
            }
            string errorMessage = string.Join("\n ", errors);
            return View(category);
        }

        private bool CategoryExists(int id)
        {
            return _dataContext.Categories.Any(e => e.Id == id);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _dataContext.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _dataContext.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _dataContext.Categories.Remove(category);
            await _dataContext.SaveChangesAsync();

            TempData["success"] = "Xóa danh mục thành công.";
            return RedirectToAction(nameof(Index));
        }

    }

}
