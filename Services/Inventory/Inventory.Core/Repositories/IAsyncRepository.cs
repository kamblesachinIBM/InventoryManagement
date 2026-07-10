using System.Linq.Expressions;
using Inventory.Core.Entities;

namespace Inventory.Core.Repositories
{
    public interface IAsyncRepository<T> where T : EntityBase
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> GetByWarehouseIdAsync(int warehouseId);
        Task<T> AddAsync(T entity);
        Task<bool> UpdateAsync(T newEntity, T oldEntity);
        Task<bool> DeleteAsync(T entity);
    }
}
