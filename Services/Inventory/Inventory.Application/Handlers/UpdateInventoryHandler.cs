using MediatR;
using Inventory.Application.Commands;
using Inventory.Application.Mappers;
using Inventory.Application.Responses;
using Inventory.Core.Repositories;

namespace Inventory.Application.Handlers
{
    public class UpdateInventoryHandler : IRequestHandler<UpdateInventoryCommand, InventoryResponse>
    {
        private readonly IInventoryRepository _repository;

        public UpdateInventoryHandler(IInventoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<InventoryResponse> Handle(UpdateInventoryCommand request, CancellationToken cancellationToken)
        {
            var inventory = await _repository.GetByIdAsync(request.Id);
            var inventoryEntity = request.ToEntity();

            await _repository.UpdateAsync(inventoryEntity, inventory);

            return inventoryEntity.ToResponse();
        }
    }
}
