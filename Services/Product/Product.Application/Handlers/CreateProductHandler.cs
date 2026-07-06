using MediatR;
using Product.Application.Commands;
using Product.Application.Mappers;
using Product.Application.Responses;
using Product.Core.Repositories;
using Product.Infrastructure.Data;

namespace Product.Application.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductResponse>
    {
        private readonly IProductRepository _repository;

        protected readonly ProductDbContext _dbContext;

        public CreateProductHandler(IProductRepository repository, ProductDbContext dbContext)
        {
            _repository = repository;
            _dbContext = dbContext;
        }

        public async Task<ProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productEntity = request.ToEntity();
            await _dbContext.AddAsync(productEntity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            //var addedProduct = await _repository.AddAsync(productEntity);
            //return addedProduct.ToResponse();
            return productEntity.ToResponse();
        }
    }
}
