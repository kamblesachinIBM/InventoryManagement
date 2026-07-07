using MediatR;
using Product.Application.Responses;

namespace Product.Application.Queries
{
    public class GetAllProductQuery : IRequest<List<ProductResponse>>
    {
    }
}
