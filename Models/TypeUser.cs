using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodCorner.Models
{
    public class TypeUser : IdentityUser
    {
        public string Address { get; set; }
        public Cart Cart { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
