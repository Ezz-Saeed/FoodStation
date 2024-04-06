using FoodCorner.Models;
using FoodCorner.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FoodCorner.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IItemsService _itemsService;
        public HomeController(ILogger<HomeController> logger, IItemsService itemsService)
        {
            _logger = logger;
            _itemsService = itemsService;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _itemsService.GetItems("Category");
            return View(items);
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}