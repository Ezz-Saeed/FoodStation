using System.Linq.Expressions;

namespace FoodCorner.Repository.Base
{
    public interface IMainRepository<T> where T : class
    {
        Task Create(T model);
        T GetById(int id);
        Task <IEnumerable<T>> GetAll(params string[]? eagers);
        Task<T>? GetOne(Expression <Func<T, bool>> predicate, params string[]? eagers);
        void Delete(T model);
        bool Update(T model);
        Task<IEnumerable<T>> GetCollection(Expression<Func<T, bool>> predicate, params string[]? eagers);
        
    }
}
