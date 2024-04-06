using FoodCorner.Models;
using FoodCorner.Repository.Base;
using FoodCorner.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FoodCorner.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrdersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> ViewAllOrders() 
        {
            var orders = await _unitOfWork.Orders.GetAll("TypeUser");
            return View(orders);
        }
        public async Task<IActionResult> OrderDetails(string id)
        {
            var order = await _unitOfWork.Orders.GetOne(o => o.Id == id,"TypeUser")!;
            var orderedItems = await _unitOfWork.OrderedItems.GetCollection(oi => oi.Order!.Id == id, "Item")!;
            OrderViewModel orderViewModel = new ()
            {
                //UserName = order.TypeUser.UserName!,
                //Address = order.TypeUser.Address,
                //ItemName = orderedItem.Item!.Name,
                Order = order,
                OrderedItems = orderedItems,
            };
            return View(orderViewModel);
        }

        public async Task<IActionResult> ProcessOrder(string id)
        {
            var order = await _unitOfWork.Orders.GetOne(o => o.Id == id)!;
            var orderedItems = await _unitOfWork.OrderedItems.GetCollection(oi => oi.Order!.Id == id)!;
            _unitOfWork.Orders.Delete(order);
            foreach (var item in orderedItems)
            {
                _unitOfWork.OrderedItems.Delete(item);
            }
            _unitOfWork.Commit();
            return NoContent();
        }
        public async Task<IActionResult> ConfirmOrder()
        {
            var userCartId = User.Claims.Single(c => c.Type == "CartId").Value;
            var userId = User.Claims.Single(c => c.Type == "UserId").Value;
            int totalQuantity = 0;
            decimal totalPrice = 0; 
            var orderedItems = await _unitOfWork.OrderedItems.GetCollection(oi => oi.CartId == userCartId,"Item");
            totalQuantity =  orderedItems.Select(oi => oi.Quantity).Sum();
            totalPrice += orderedItems.Select(oi => oi.Price).Sum();
            Order order = new()
            {
                TotalPrice = totalPrice,
                TotalQuantity = totalQuantity,
                UserId = userId,
            };
            await _unitOfWork.Orders.Create(order);
            foreach (var item in orderedItems)
            {
                item.Orderid = order.Id;
                //_unitOfWork.OrderedItems.Update(item);
            }
            _unitOfWork.Commit();
            return NoContent();
        }
    }
}
