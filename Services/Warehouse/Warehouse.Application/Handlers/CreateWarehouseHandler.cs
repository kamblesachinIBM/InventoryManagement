using MediatR;
using Warehouse.Application.Commands;
using Warehouse.Application.Mappers;
using Warehouse.Application.Responses;
using Warehouse.Core.Repositories;

namespace Warehouse.Application.Handlers
{
    public class CreateWarehouseHandler : IRequestHandler<CreateWarehouseCommand, WarehouseResponse>
    {
        private readonly IWareHouseRepository _repository;

        public CreateWarehouseHandler(IWareHouseRepository repository)
        {
            _repository = repository;
        }
        public async Task<WarehouseResponse> Handle(CreateWarehouseCommand request, CancellationToken cancellationToken)
        {
            var warehouseEntity = request.ToEntity();
            var addedWarehouse = await _repository.AddAsync(warehouseEntity);

            return addedWarehouse.ToResponse();
        }
    }
}
