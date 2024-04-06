using FoodCorner.Models;
using FoodCorner.ViewModels;

namespace FoodCorner.Services.IServices
{
    public interface IItemsService
    {
        Task Create(CreateMealeVeiwModel viewModel);
        Task<IEnumerable<Item>> GetItems(params string[]? eagers);
        Task<Item> GetItem(int id, params string[]? eagers);
        Task<Item?> Update(EditItemViewModel viewModel);
        void Delete(int id);
    }
}
