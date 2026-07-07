using Warehouse.Core.Entities;

namespace Warehouse.Core.Repositories
{
    public interface IWareHouseRepository : IAsyncRepository<WarehouseEntity>
    {
        Task<IEnumerable<WarehouseEntity>> GetWarehouseByName(string name);
    }
}
