using MediatR;
using Warehouse.Application.Responses;

namespace Warehouse.Application.Queries
{
    public record GetWarehouseByIdQuery(int Id) : IRequest<WarehouseResponse>
    {
        
    }
}
