using FoodCorner.Models;

namespace FoodCorner.Repository.Base
{
    public interface IUnitOfWork 
    {
        IMainRepository<Item> Items { get; }
        IMainRepository<Category> Categories { get; }
        IMainRepository<OrderedItem> OrderedItems { get; }
        IMainRepository<Order> Orders { get; }
        int Commit();
    }
}
