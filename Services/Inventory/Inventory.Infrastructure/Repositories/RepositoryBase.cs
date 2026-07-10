using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Inventory.Core.Entities;
using Inventory.Core.Repositories;
using Inventory.Infrastructure.Data;

namespace Inventory.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IAsyncRepository<T> where T : EntityBase
    {
        protected readonly InventoryDbContext _dbContext;

        public RepositoryBase(InventoryDbContext context)
        {
            _dbContext = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            try
            {
                _dbContext.Set<T>().Remove(entity);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }
        public async Task<T> GetByWarehouseIdAsync(int WarehouseId)
        {
            return await _dbContext.Set<T>().FindAsync(WarehouseId);
        }

        public async Task<bool> UpdateAsync(T newEntity, T existingEntity)
        {
            try
            {
                // _dbContext.Entry(entity).State = EntityState.Modified;
                _dbContext.Entry(existingEntity).CurrentValues.SetValues(newEntity);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
