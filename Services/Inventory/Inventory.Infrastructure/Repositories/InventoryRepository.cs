using Microsoft.EntityFrameworkCore;
using Inventory.Core.Entities;
using Inventory.Core.Repositories;
using Inventory.Infrastructure.Data;

namespace Inventory.Infrastructure.Repositories
{
    public class InventoryRepository : RepositoryBase<InventoryEntity>, IInventoryRepository
    {
        public InventoryRepository(InventoryDbContext context) : base(context) { }

        public async Task<IEnumerable<InventoryEntity>> GetInventoryByProduct(int prodId)
        {
            return await _dbContext.Inventory
                .AsNoTracking()
                .Where(o => o.ProductId == prodId)
                .ToListAsync();
        }
    }
}
