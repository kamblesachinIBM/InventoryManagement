using MediatR;
using Inventory.Application.DTOs;
using Inventory.Application.Mappers;
using Inventory.Application.Queries;
using Inventory.Core.Repositories;

namespace Inventory.Application.Handlers
{
    public class GetAllInventoryHandler : IRequestHandler<GetAllInventoryQuery, List<InventoryDto>>
    {
        private readonly IInventoryRepository _repository;

        public GetAllInventoryHandler(IInventoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<InventoryDto>> Handle(GetAllInventoryQuery request, CancellationToken cancellationToken)
        {
            var inventories = await _repository.GetAllAsync();

            return inventories.Select(i => i.ToDto()).ToList();
        }
    }
}
