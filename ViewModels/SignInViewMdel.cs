using System.ComponentModel.DataAnnotations;

namespace FoodCorner.ViewModels
{
    public class SignInViewMdel
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        [Display(Name ="Remember Me")]
        public bool RemeberMe { get; set; } = default!;
    }
}
