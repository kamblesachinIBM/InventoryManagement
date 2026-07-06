using Product.Core.Entities;

namespace Product.Core.Repositories
{
    public interface IProductRepository : IAsyncRepository<ProductEntity>
    {
        Task<IEnumerable<ProductEntity>> GetProductByNameAsync(string name);
    }
}
