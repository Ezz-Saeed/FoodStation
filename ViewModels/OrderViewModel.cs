using FoodCorner.Models;

namespace FoodCorner.ViewModels
{
    public class OrderViewModel
    {
        //public string UserName { get; set; }
        //public string Address { get; set; }
        //public string ItemName { get; set; }
        //public int Quantity { get; set; }
        //public decimal Price { get; set; }
        //public string Category { get; set; }
        //public int TotalQuantity { get; set; }
        //public decimal TotalPrice { get; set; }
        public Order Order { get; set; }
        public IEnumerable<OrderedItem> OrderedItems { get; set; }
    }
}
