using FoodCorner.Data;
using FoodCorner.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FoodCorner.Repository
{
    public class MainRepository<T> : IMainRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        public MainRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(T model)
        {
            await _context.Set<T>().AddAsync(model);
           
        }
        public T GetById(int id)
        {
            return _context.Set<T>().Find(id)!;
        }
        public void Delete(T model)
        {
           _context.Set<T>().Remove(model);
        }

        public async Task<IEnumerable<T>> GetAll(params string[]? eagers)
        {
            IQueryable<T> values = _context.Set<T>();
            if(eagers is not null && eagers.Length > 0)
            {
                foreach(var eager in eagers)
                {
                    values = values.Include(eager);
                }
            }
            return await values.ToListAsync();
        }

        public async Task<T?> GetOne(Expression<Func<T, bool>> predicate, params string[]? eagers)
        {
            IQueryable<T> values = _context.Set<T>();
            if (eagers is not null && eagers.Length > 0)
            {
                foreach (var eager in eagers)
                {
                    values = values.Include(eager);
                }
            }
            var value = await values.SingleOrDefaultAsync(predicate) ?? null;
            return  value;
        }

        public bool Update(T model)
        {
            _context.Set<T>().Update(model);
            return _context.SaveChanges() > 0 ? true:false;
        }

        public async Task<IEnumerable<T>> GetCollection(Expression<Func<T, bool>> predicate, params string[]? eagers)
        {    
                var result = _context.Set<T>().Where(predicate);
                if (eagers is not null && eagers.Length > 0)
                {
                    foreach (var eager in eagers)
                        result = result.Include(eager);
                }
                return result;
           
        }
    }
}
