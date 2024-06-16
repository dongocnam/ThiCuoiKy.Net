using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ThiCuoiKy.Net.Models;
using ThiCuoiKy.Net.Models.ViewModels;
using System.Threading.Tasks;

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

		public IActionResult Login(string returnUrl)
		{
			return View(new LoginViewModel { ReturnUrl = returnUrl });
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel loginVM)
		{
			if (ModelState.IsValid)
			{
				Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(loginVM.UserName,
																											 loginVM.Password,
																											 false,
																											 false);
				if (result.Succeeded)
				{
					return Redirect(loginVM.ReturnUrl ?? "/");
				}
				ModelState.AddModelError("", "Tên người dùng và mật khẩu không hợp lệ");
			}
			return View(loginVM);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(UserModel user)
		{
			if (ModelState.IsValid)
			{
				AppUserModel newUser = new AppUserModel { UserName = user.UserName, Email = user.Email };
				IdentityResult result = await _userManager.CreateAsync(newUser, user.Password); // Thêm mật khẩu vào đây

				if (result.Succeeded)
				{
					TempData["success"] = "Đăng kí thành công tài khoản";
					return RedirectToAction("Login"); // Chuyển hướng về trang đăng nhập sau khi tạo tài khoản thành công
				}

				foreach (IdentityError error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
			}
			return View(user);
		}

		public async Task<IActionResult> Logout(string returnUrl = "/")
		{
			await _signInManager.SignOutAsync();	
			return Redirect(returnUrl);
		}

    }
}
