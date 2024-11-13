
using Economizze.Library;
using StoreApp.Wrapper;

namespace StoreApp.Services.Interfaces
{
    public interface IService<T> where T : class
    {
        Task<Result<IEnumerable<StoreType>>> GetAllAsync();
        //Task<T?> GetByIdAsync(int id);
        Task<Result<T>> AddAsync(T entity);
        Task<Result<T>> GetByIdAsync(int id);
        Task<Result<T>> UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
