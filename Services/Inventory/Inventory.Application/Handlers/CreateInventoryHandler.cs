using MediatR;
using Inventory.Application.Commands;
using Inventory.Application.Mappers;
using Inventory.Application.Responses;
using Inventory.Core.Repositories;

namespace Inventory.Application.Handlers
{
    public class CreateInventoryHandler : IRequestHandler<CreateInventoryCommand, InventoryResponse>
    {
        private readonly IInventoryRepository _repository;

        public CreateInventoryHandler(IInventoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<InventoryResponse> Handle(CreateInventoryCommand request, CancellationToken cancellationToken)
        {
            var inventoryEntity = request.ToEntity();
            var addedInventory = await _repository.AddAsync(inventoryEntity);

            return addedInventory.ToResponse();
        }
    }
}
