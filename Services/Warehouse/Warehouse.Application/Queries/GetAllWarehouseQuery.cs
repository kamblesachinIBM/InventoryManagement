using MediatR;
using Warehouse.Application.Responses;

namespace Warehouse.Application.Queries
{
    public record GetAllWarehouseQuery : IRequest<List<WarehouseResponse>>
    {
        
    }
}
