using MediatR;
using Product.Application.Responses;

namespace Product.Application.Queries
{
    public record GetProductByIdQuery(int Id) : IRequest<ProductResponse>;
}
