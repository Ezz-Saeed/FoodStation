using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace FoodCorner.ViewModels
{
    public class BaseItemViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        [Required(ErrorMessage = "Price si required")]
        public decimal Price { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();
        [Display(Name = "Category")]

        public int CategoryId { get; set; }
    }
}
