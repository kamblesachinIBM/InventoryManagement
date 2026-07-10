using Inventory.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Queries
{
    public record GetInventoryByWarehouseIdQuery : IRequest<InventoryDto>
    {
        public int WarehouseId { get; init; }

        public GetInventoryByWarehouseIdQuery(int warehouseId)
        {
            WarehouseId = warehouseId;
        }
    }
}
