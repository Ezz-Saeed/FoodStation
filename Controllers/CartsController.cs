using FoodCorner.Repository.Base;
using Microsoft.AspNetCore.Mvc;

namespace FoodCorner.Controllers
{
    public class CartsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CartsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> ViewCart()
        {
            var userCartId = User.Claims.Single(c => c.Type == "CartId").Value;
            var items = await _unitOfWork.OrderedItems.GetCollection(oi => oi.CartId == userCartId, "Item","Cart");
            if (items is not  null) 
                return View(items);
            return BadRequest("No Ordered Items");
        }

        public async Task<IActionResult> Remove(string cartId, int itemId)
        {
            var item = await _unitOfWork.OrderedItems.GetOne(oi => oi.ItemId == itemId && oi.CartId == cartId, "Item")!;
            item.Price -= item.Item!.Price;
            if (item.Quantity > 1)
                item.Quantity -= 1;
            else
                _unitOfWork.OrderedItems.Delete(item);
            _unitOfWork.Commit();
            return NoContent();
        }
    }
}
