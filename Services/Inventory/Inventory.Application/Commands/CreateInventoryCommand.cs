using MediatR;
using Inventory.Application.Responses;

namespace Inventory.Application.Commands
{
    public record CreateInventoryCommand : IRequest<InventoryResponse>
    {
        public int ProductId { get; set; }
        public int WarehouseId { get; set; }
        public int Quantity { get; set; }
        public bool Status { get; init; }
    }
}
