using MediatR;
using Inventory.Application.DTOs;

namespace Inventory.Application.Queries
{
    public record GetInventoryByIdQuery : IRequest<InventoryDto>
    {
        public int Id { get; init; }

        public GetInventoryByIdQuery(int id)
        {
            Id = id;
        }
    }
}
