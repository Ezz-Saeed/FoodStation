using System.ComponentModel.DataAnnotations;

namespace FoodCorner.ViewModels
{
    public class RegisterationViewModel
    {
        [Display(Name ="User Name")]
        public string UserName { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Confirm Password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; } = string.Empty;
        public string Address { get; set; }
    }
}
