
using Economizze.Library;
using StoreApp.Wrapper;

namespace StoreApp.Services.Interfaces
{
    public interface IService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        //Task<T?> GetByIdAsync(int id);
        Task<Result<Store>> AddAsync(T entity);
        Task<Result<Store>> GetByIdAsync(int id);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
