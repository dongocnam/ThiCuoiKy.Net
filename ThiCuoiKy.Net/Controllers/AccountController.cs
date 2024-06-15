using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using ThiCuoiKy.Net.Models;

namespace ThiCuoiKy.Net.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUserModel> _userManager;
        private SignInManager<AppUserModel> _signInManager;
        public AccountController(SignInManager<AppUserModel> signInManager, UserManager<AppUserModel> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager; 
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Login()
        {
            return View();
        }
	
		public async Task<IActionResult> Create(UserModel user)
        {
			if (ModelState.IsValid)
			{
                AppUserModel newUser = new AppUserModel { UserName = user.UserName, Email = user.Email };
                IdentityResult result = await _userManager.CreateAsync(newUser);
                if(result.Succeeded)
                {
                    return Redirect("/admin/products");
                }
                foreach(IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
				
			}
			return View(user);
        }

        
    }

	
}
