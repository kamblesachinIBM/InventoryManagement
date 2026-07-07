using MediatR;
using Warehouse.Application.Commands;
using Warehouse.Application.Mappers;
using Warehouse.Core.Repositories;

namespace Warehouse.Application.Handlers
{
    public class UpdateWarehouseHandler : IRequestHandler<UpdateWarehouseCommand, bool>
    {
        private readonly IWareHouseRepository _repository;

        public UpdateWarehouseHandler(IWareHouseRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateWarehouseCommand request, CancellationToken cancellationToken)
        {
            // Get existing Warehouse by Id
            var existingWarehouse = await _repository.GetByIdAsync(request.Id);

            if (existingWarehouse == null)
            {
                // Throw an exception or return false if the warehouse does not exist
                throw new KeyNotFoundException($"Warehouse with id {request.Id} not found");
            }

            var toUpdateEntity = request.ToEntity();

            return await _repository.UpdateAsync(toUpdateEntity, existingWarehouse);
        }
    }
}
