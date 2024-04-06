using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodCorner.Models
{
    public class OrderedItem
    {
        //public string Id { get; set; } = Guid.NewGuid().ToString();
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int ItemId { get; set; }
        public Item? Item { get; set; }
        public string CartId { get; set; }
        public Cart? Cart { get; set; }
        [ForeignKey(nameof(Order))]
        public string? Orderid { get; set; }
        public Order? Order { get; set; }
    }
}
