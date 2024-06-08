using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

namespace ThiCuoiKy.Net.Repository.Components
{
	public class BrandsViewComponent : ViewComponent {
		private  readonly DataContext _dataContext;

		public BrandsViewComponent(DataContext context)
	{
			_dataContext = context;
	}
		public async Task<IViewComponentResult> InvokeAsync() => View( await _dataContext.Brands.ToListAsync());
	}
}
