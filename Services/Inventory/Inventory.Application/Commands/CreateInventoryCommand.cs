using MediatR;
using Inventory.Application.Responses;

namespace Inventory.Application.Commands
{
    public record CreateInventoryCommand : IRequest<InventoryResponse>
    {
        public string? Code { get; init; }
        public string? Name { get; init; }
        public int Quantity { get; init; }
        public string? Location { get; init; }
        public bool Status { get; init; }
    }
}
