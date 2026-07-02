using MediatR;
using Warehouse.Application.Mappers;
using Warehouse.Application.Queries;
using Warehouse.Application.Responses;
using Warehouse.Core.Repositories;

namespace Warehouse.Application.Handlers
{
    public class GetWarehouseByIdHandler : IRequestHandler<GetWarehouseByIdQuery, WarehouseResponse>
    {
        private readonly IWareHouseRepository _repository;

        public GetWarehouseByIdHandler(IWareHouseRepository repository)
        {
            _repository = repository;
        }

        public async Task<WarehouseResponse> Handle(GetWarehouseByIdQuery request, CancellationToken cancellationToken)
        {
            var warehouseDetails = await _repository.GetByIdAsync(request.Id);

            return warehouseDetails.ToResponse();
        }
    }
}
