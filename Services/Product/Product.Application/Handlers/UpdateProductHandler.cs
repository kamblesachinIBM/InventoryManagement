using MediatR;
using Product.Application.Commands;
using Product.Application.Mappers;
using Product.Core.Repositories;

namespace Product.Application.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductRepository _repository;
        public UpdateProductHandler(IProductRepository productRepository)
        {
            _repository = productRepository;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var existingProductEntity = await _repository.GetByIdAsync(request.Id);

            if (existingProductEntity == null)
            {
                throw new Exception($"Product with ID {request.Id} not found.");
            }

            var productEntity = request.ToEntity();

            return await _repository.UpdateAsync(productEntity, existingProductEntity);
        }
    }
}
