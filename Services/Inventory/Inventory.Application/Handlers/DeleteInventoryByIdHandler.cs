using MediatR;
using Inventory.Application.Commands;
using Inventory.Application.Mappers;
using Inventory.Core.Repositories;

namespace Inventory.Application.Handlers
{
    public class DeleteInventoryByIdHandler : IRequestHandler<DeleteInventoryByIdCommand, bool>
    {
        private readonly IInventoryRepository _repository;

        public DeleteInventoryByIdHandler(IInventoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteInventoryByIdCommand request, CancellationToken cancellationToken)
        {
            var inventory = await _repository.GetByIdAsync(request.Id);

            return await _repository.DeleteAsync(inventory);
        }
    }
}
