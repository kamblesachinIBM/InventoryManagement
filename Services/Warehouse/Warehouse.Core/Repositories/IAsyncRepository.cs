using System.Linq.Expressions;
using Warehouse.Core.Entities;

namespace Warehouse.Core.Repositories
{
    public interface IAsyncRepository<T> where T : EntityBase
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<bool> UpdateAsync(T newEntity, T oldEntity);
        Task<bool> DeleteAsync(T entity);
    }
}
