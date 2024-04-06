using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodCorner.Models
{
    public class Order
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public ICollection<OrderedItem> OrderedItems { get; set; }
        public decimal TotalPrice { get; set; }
        public int TotalQuantity { get; set; }
        [ForeignKey(nameof(TypeUser))]
        public string UserId { get; set; }
        public TypeUser TypeUser { get; set; }
        
    }
}
