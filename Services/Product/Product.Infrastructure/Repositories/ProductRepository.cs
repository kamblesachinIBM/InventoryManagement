using Microsoft.EntityFrameworkCore;
using Product.Core.Entities;
using Product.Core.Repositories;
using Product.Infrastructure.Data;

namespace Product.Infrastructure.Repositories
{
    public class ProductRepository : RepositoryBase<ProductEntity>, IProductRepository
    {
        public ProductRepository(ProductDbContext context) : base(context) { }

        public async Task<IEnumerable<ProductEntity>> GetProductByNameAsync(string name)
        {
            return await _dbContext.Products
                .AsNoTracking()
                .Where(o => o.Name == name)
                .ToListAsync();
        }
    }
}
