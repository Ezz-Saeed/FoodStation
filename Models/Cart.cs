using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodCorner.Models
{
    public class Cart
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public ICollection<Item>? Items { get; set; }
        public ICollection<OrderedItem>? OrderedItems { get; set; }
        [ForeignKey(nameof(User))]
        public string UserID { get; set; }
        public TypeUser User { get; set; }
    }
}
