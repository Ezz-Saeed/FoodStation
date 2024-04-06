using Microsoft.AspNetCore.Mvc.Rendering;

namespace FoodCorner.Services.IServices
{
    public interface ICategoriesService
    {
        Task<IEnumerable<SelectListItem>> GetCategories();
    }
}
