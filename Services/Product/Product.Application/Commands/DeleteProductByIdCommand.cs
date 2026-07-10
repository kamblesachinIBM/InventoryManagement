using MediatR;

namespace Product.Application.Commands
{
    public record DeleteProductByIdCommand(int Id) : IRequest<bool>;
}
