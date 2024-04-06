using FoodCorner.Data;
using FoodCorner.Repository.Base;
using FoodCorner.Services.IServices;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FoodCorner.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoriesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<SelectListItem>> GetCategories()
        {
            var categories = await _unitOfWork.Categories.GetAll();
            return categories.Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString()})
                .OrderBy(c => c.Text)
                .ToList();
                
        }
    }
}
