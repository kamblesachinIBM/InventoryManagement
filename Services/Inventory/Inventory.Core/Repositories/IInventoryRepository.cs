using Inventory.Core.Entities;

namespace Inventory.Core.Repositories
{
    public interface IInventoryRepository : IAsyncRepository<InventoryEntity>
    {
        Task<IEnumerable<InventoryEntity>> GetInventoryByProduct(int prodId);

    }
}
