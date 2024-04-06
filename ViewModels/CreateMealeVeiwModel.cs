using FoodCorner.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodCorner.ViewModels
{
    public class CreateMealeVeiwModel : BaseItemViewModel
    {
        
        
        public IFormFile Image { get; set; } = default!;

    }
}
