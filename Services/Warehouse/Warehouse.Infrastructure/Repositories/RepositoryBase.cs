using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Warehouse.Core.Entities;
using Warehouse.Core.Repositories;
using Warehouse.Infrastructure.Data;

namespace Warehouse.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IAsyncRepository<T> where T : EntityBase
    {
        protected readonly WarehouseDbContext _dbContext;

        public RepositoryBase(WarehouseDbContext context)
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
