using System.ComponentModel.DataAnnotations.Schema;

namespace FoodCorner.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; } = default!;
        public string ImagePath { get; set; } = string.Empty;
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; } =  default!;
        public Category Category { get; set; } = default!;
        //public string? CartId { get; set; } = default!;
        public ICollection<Cart>? Carts { get; set; } = default!;
        public ICollection<OrderedItem>? OrderedItems { get; set; }
    }
}
