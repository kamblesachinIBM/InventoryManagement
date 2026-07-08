using MediatR;
using Inventory.Application.DTOs;
using Inventory.Application.Mappers;
using Inventory.Application.Queries;
using Inventory.Core.Repositories;

namespace Inventory.Application.Handlers
{
    public class GetInventoryByIdHandler : IRequestHandler<GetInventoryByIdQuery, InventoryDto>
    {
        private readonly IInventoryRepository _repository;

        public GetInventoryByIdHandler(IInventoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<InventoryDto> Handle(GetInventoryByIdQuery request, CancellationToken cancellationToken)
        {
            var inventory = await _repository.GetByIdAsync(request.Id);

            return inventory.ToDto();
        }
    }
}
