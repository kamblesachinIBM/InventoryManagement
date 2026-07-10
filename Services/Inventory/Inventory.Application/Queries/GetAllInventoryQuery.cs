using MediatR;
using Inventory.Application.DTOs;

namespace Inventory.Application.Queries
{
    public record GetAllInventoryQuery : IRequest<List<InventoryDto>>
    {
    }
}
