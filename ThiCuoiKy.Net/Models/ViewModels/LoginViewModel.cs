using System.ComponentModel.DataAnnotations;

namespace ThiCuoiKy.Net.Models.ViewModels
{
	public class LoginViewModel
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Yêu cầu nhập tên đăng nhập")]
		public string UserName { get; set; }
		[DataType(DataType.Password), Required(ErrorMessage = "Yêu cầu nhập mật khẩu")]
		public string Password { get; set; }
		public string ReturnUrl { get; set; }
		
	}
}
