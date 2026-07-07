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


        public CreateProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productEntity = request.ToEntity();
            var addedProduct = await _repository.AddAsync(productEntity);
            return addedProduct.ToResponse();
        }
    }
}
