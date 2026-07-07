using MediatR;

namespace Warehouse.Application.Commands
{
    public record DeleteWarehouseByIdCommand(int Id) : IRequest<bool>;
}
