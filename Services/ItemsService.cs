using FoodCorner.Data;
using FoodCorner.Models;
using FoodCorner.Repository.Base;
using FoodCorner.Services.IServices;
using FoodCorner.Settings;
using FoodCorner.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FoodCorner.Services
{
    public class ItemsService : IItemsService

    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _environment;
        private readonly string _filePath;
        public ItemsService(IUnitOfWork unitOfWork, IWebHostEnvironment environment)
        {
            _unitOfWork = unitOfWork;
            _environment = environment;
            _filePath = $"{_environment.WebRootPath}{FileSettings.FilePath}";
        }
        public async Task Create(CreateMealeVeiwModel viewModel)
        {
            var image = await SaveFile(viewModel.Image);
            Item item = new()
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                CategoryId = viewModel.CategoryId,
                Price = viewModel.Price,
                ImagePath = image
            };
            await _unitOfWork.Items.Create(item);
            _unitOfWork.Commit();
        }

        public async Task<IEnumerable<Item>> GetItems(params string[]? eagers)
        {
            return await _unitOfWork.Items.GetAll(eagers);
        }

        public async Task<Item> GetItem(int id, params string[]? eagers)
        {
            return await _unitOfWork.Items.GetOne(i => i.Id == id, eagers);
        }

        public async Task<Item?> Update(EditItemViewModel viewModel)
        {
            var oldItem = await _unitOfWork.Items.GetOne(i => i.Id == viewModel.Id,"Category");
            if (oldItem is null)
                return null;
            var oldImage = oldItem.ImagePath;
            var hasNewImage = viewModel.Image is not null;
            oldItem.Name = viewModel.Name;
            oldItem.Description = viewModel.Description;
            oldItem.Price = viewModel.Price;
            oldItem.CategoryId = viewModel.CategoryId;
            if (hasNewImage)
            {
                oldItem.ImagePath = await SaveFile(viewModel.Image!);
            }
            var affectedRows = _unitOfWork.Commit();
            if(affectedRows > 0)
            {
                if (hasNewImage)
                {
                    var image = Path.Combine(_filePath, oldImage);
                    File.Delete(image);
                }
                return oldItem;

            }
            else
            {
                var image = Path.Combine(_filePath, oldItem.ImagePath);
                File.Delete(image);
                return null;
            }
        }


        private async Task<string> SaveFile(IFormFile file)
        {
            var fileName = $"{Guid.NewGuid()}{file.FileName}";
            var filePath = Path.Combine(_filePath,fileName);

            using(var stream = File.Create(filePath))
            {
                await file.CopyToAsync(stream);
            }
            return fileName;
        }

        public async void Delete(int id)
        {
            var item = await _unitOfWork.Items.GetOne(i => i.Id == id);
            _unitOfWork.Items.Delete(item);
            //context.Items.Remove(item);
            _unitOfWork.Commit();
        }
    }
}
