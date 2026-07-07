using MediatR;
using Warehouse.Application.Mappers;
using Warehouse.Application.Queries;
using Warehouse.Application.Responses;
using Warehouse.Core.Repositories;

namespace Warehouse.Application.Handlers
{
    public class GetAllWarehouseHandler : IRequestHandler<GetAllWarehouseQuery, List<WarehouseResponse>>
    {
        private readonly IWareHouseRepository _repository;
        public GetAllWarehouseHandler(IWareHouseRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<WarehouseResponse>> Handle(GetAllWarehouseQuery request, CancellationToken cancellationToken)
        {
            var warehouses = await _repository.GetAllAsync();

            return warehouses.ToDtoList();
        }
    }
}
