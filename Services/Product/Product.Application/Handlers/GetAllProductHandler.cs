using MediatR;
using Product.Application.Mappers;
using Product.Application.Queries;
using Product.Application.Responses;
using Product.Core.Repositories;

namespace Product.Application.Handlers
{

    public class GetAllProductHandler : IRequestHandler<GetAllProductQuery, List<ProductResponse>>
    {
        private readonly IProductRepository _repository;

        public GetAllProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<ProductResponse>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetAllAsync();
            return products.ToDtoList();
        }
    }
}
