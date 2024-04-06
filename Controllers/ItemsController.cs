using FoodCorner.Data;
using FoodCorner.Models;
using FoodCorner.Repository.Base;
using FoodCorner.Services.IServices;
using FoodCorner.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodCorner.Controllers
{
    public class ItemsController : Controller
    {
        private readonly ICategoriesService _categoriesService;
        private readonly IItemsService _itemsService;
        private readonly IUnitOfWork _unitOfWork;
        public ItemsController(ICategoriesService categoriesService, IItemsService itemsService, IUnitOfWork unitOfWork)
        {
            _categoriesService = categoriesService;
            _itemsService = itemsService;
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var items = await _itemsService.GetItems("Category");
            return View(items);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            CreateMealeVeiwModel createMealeVeiwModel = new()
            {
                Categories = await _categoriesService.GetCategories(),
            };

            return View(createMealeVeiwModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Create(CreateMealeVeiwModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await _categoriesService.GetCategories();
                return View(model);
            }

            await _itemsService.Create(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            //var orderedItem = await context.Items.Include(i => i.Category).SingleOrDefaultAsync(i => i.Id == id);
            var item = await _itemsService.GetItem(id,"Category");
            if(item is null)
                return NotFound();
            return View(item);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var item = await _itemsService.GetItem(id, "Category");
            if(item is null)
                return NotFound();
            EditItemViewModel viewModel = new()
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                CategoryId = item.CategoryId,
                Categories = await _categoriesService.GetCategories(),
                CurrentImage = item.ImagePath,
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(EditItemViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = await _categoriesService.GetCategories();
                return View(viewModel);
            }
            var item = await _itemsService.Update(viewModel);
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _itemsService.GetItem(id);
            if (item is null) 
                return NotFound();
            EditItemViewModel viewModel = new()
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                CategoryId = item.CategoryId,
                Categories = await _categoriesService.GetCategories(),
                CurrentImage = item.ImagePath,
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(EditItemViewModel viewModel, [FromServices] AppDbContext context)
        {
            var item = await _itemsService.GetItem(viewModel.Id);
            //_itemsService.Delete(viewModel.Id);
            context.Items.Remove(item);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task <IActionResult> OrderItem([FromRoute] int id)
        {
            var cartId = User.Claims.FirstOrDefault(c => c.Type == "CartId")!.Value;
            var orderedItem = await _unitOfWork.OrderedItems.GetOne(oi => oi.ItemId == id && oi.CartId == cartId, "Item")!;
            if (orderedItem is not null)
            {
                orderedItem.Quantity += 1;
                orderedItem.Price = (orderedItem.Quantity) * orderedItem.Item!.Price;
            }
               
            else
            {
                OrderedItem newOrderedItem = new()
                {
                    ItemId = id,
                    CartId = cartId,
                    Quantity = 1,
                    Price = _unitOfWork.Items.GetById(id).Price,
                };
                await _unitOfWork.OrderedItems.Create(newOrderedItem);
            }
            _unitOfWork.Commit();
            return NoContent();
        }
       
    }

}
