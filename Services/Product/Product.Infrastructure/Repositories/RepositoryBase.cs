using Microsoft.EntityFrameworkCore;
using Product.Core.Entities;
using Product.Core.Repositories;
using Product.Infrastructure.Data;

namespace Product.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IAsyncRepository<T> where T : EntityBase
    {
        protected readonly ProductDbContext _dbContext;

        public RepositoryBase(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
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
            catch (Exception)
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

        public async Task<bool> UpdateAsync(T newEntity, T oldEntity)
        {
            _dbContext.Entry(oldEntity).CurrentValues.SetValues(newEntity);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
