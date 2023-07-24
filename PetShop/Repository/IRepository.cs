using PetShop.Models;

namespace PetShop.Repository
{
    public interface IRepository<T>
    {
        Task AddAsync(T entity);
        Task DeleteAsync(T id);
        Task EditAsync(T entity);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task SaveAsync();

    }
}
