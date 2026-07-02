using MediatR;
using Warehouse.Application.Responses;

namespace Warehouse.Application.Commands
{
    public record CreateWarehouseCommand : IRequest<WarehouseResponse>
    {
        public string? Code { get; init; }
        public string? Name { get; init; }
        public string? Location { get; init; }
        public bool Status { get; init; }
    }
}
