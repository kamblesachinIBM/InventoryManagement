using MediatR;
using System.ComponentModel.DataAnnotations;
using Warehouse.Application.Commands;
using Warehouse.Core.Repositories;

namespace Warehouse.Application.Handlers
{
    public class DeleteWarehousebyIdHandler : IRequestHandler<DeleteWarehouseByIdCommand, bool>
    {
        private readonly IWareHouseRepository _repository;

        public DeleteWarehousebyIdHandler(IWareHouseRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteWarehouseByIdCommand request, CancellationToken cancellationToken)
        {
            // Get existing Warehouse by Id
            var existingWarehouse = await _repository.GetByIdAsync(request.Id);

            if (existingWarehouse == null)
            {
                throw new KeyNotFoundException($"Warehouse with id {request.Id} not found");
            }
            try
            {
                await _repository.DeleteAsync(existingWarehouse);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting the warehouse: {ex.Message}", ex);
            }
        }
    }
}
