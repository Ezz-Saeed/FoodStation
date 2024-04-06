using FoodCorner.Data;
using FoodCorner.Models;
using FoodCorner.Repository.Base;

namespace FoodCorner.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Items = new MainRepository<Item>(_context);
            Categories = new MainRepository<Category>(_context);
            OrderedItems = new MainRepository<OrderedItem>(_context);
            Orders = new MainRepository<Order>(_context);
        }
        public IMainRepository<Item> Items { get; private set; }

        public IMainRepository<Category> Categories { get; private set; }
        public IMainRepository<OrderedItem> OrderedItems { get; private set; }
        public IMainRepository<Order> Orders { get; private set; }

        public int Commit() => _context.SaveChanges();
        

        
    }
}
