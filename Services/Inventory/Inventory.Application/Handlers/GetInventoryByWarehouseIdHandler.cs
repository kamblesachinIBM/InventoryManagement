using Inventory.Application.DTOs;
using Inventory.Application.Mappers;
using Inventory.Application.Queries;
using Inventory.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Handlers
{
    internal class GetInventoryByWarehouseIdHandler : IRequestHandler<GetInventoryByWarehouseIdQuery, InventoryDto>
    {
        private readonly IInventoryRepository _repository;
      

        public GetInventoryByWarehouseIdHandler(IInventoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<InventoryDto> Handle(GetInventoryByWarehouseIdQuery request, CancellationToken cancellationToken)
        {
            var inventory = await _repository.GetByIdAsync(request.WarehouseId);

            return inventory.ToDto();
        }
    }
}
