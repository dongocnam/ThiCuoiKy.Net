﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThiCuoiKy.Net.Models;
using ThiCuoiKy.Net.Repository;

namespace ThiCuoiKy.Net.Controllers
{
		public class CategoryController : Controller
	{
		private readonly DataContext _dataContext;
		public CategoryController(DataContext context) { 
			_dataContext = context;
		}
			public async Task<IActionResult> Index(string Slug = "")
		{
			CategoryModel category = _dataContext.Categories.Where(c => c.Slug == Slug).FirstOrDefault();
			if (category == null)
			return RedirectToAction("Index");
			var productsByCategory = _dataContext.Products.Where(c=> c.CategoryID == category.Id);
			return View(await productsByCategory.OrderByDescending(c => c.Id).ToListAsync()) ;
		}
	}
}
