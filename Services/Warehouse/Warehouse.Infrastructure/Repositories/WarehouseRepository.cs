using Microsoft.EntityFrameworkCore;
using Warehouse.Core.Entities;
using Warehouse.Core.Repositories;
using Warehouse.Infrastructure.Data;

namespace Warehouse.Infrastructure.Repositories
{
    public class WarehouseRepository : RepositoryBase<WarehouseEntity>, IWareHouseRepository
    {
        public WarehouseRepository(WarehouseDbContext context) : base(context) { }

        public async Task<IEnumerable<WarehouseEntity>> GetWarehouseByName(string name)
        {
            return await _dbContext.Warehouse
                .AsNoTracking()
                .Where(o => o.Name == name)
                .ToListAsync();
        }
    }
}
