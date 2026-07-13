using MediatR;

namespace Inventory.Application.Commands
{
    public record DeleteInventoryByIdCommand : IRequest<bool>
    {
        public int Id { get; init; }
    }
}
