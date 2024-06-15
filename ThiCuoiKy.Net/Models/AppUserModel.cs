using Microsoft.AspNetCore.Identity;

namespace ThiCuoiKy.Net.Models
{
    public class AppUserModel : IdentityUser
    {
        public string Occupation { get; set; }
    }
}
