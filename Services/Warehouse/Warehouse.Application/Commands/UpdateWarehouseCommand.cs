using MediatR;

namespace Warehouse.Application.Commands
{
    public record UpdateWarehouseCommand : IRequest<bool>
    {
        public int Id { get; init; }
        public string? Code { get; init; }
        public string? Name { get; init; }
        public string? Location { get; init; }
        public bool Status { get; init; }
    }
}
