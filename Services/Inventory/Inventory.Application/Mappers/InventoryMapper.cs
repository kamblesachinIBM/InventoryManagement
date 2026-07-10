using Inventory.Application.Commands;
using Inventory.Application.DTOs;
using Inventory.Application.Responses;
using Inventory.Core.Entities;

namespace Inventory.Application.Mappers
{
    public static class InventoryMapper
    {
        public static InventoryDto ToDto(this InventoryEntity entity)
        {
            return new InventoryDto(
                entity.Id,
                entity.ProductId,
                entity.WarehouseId,
                entity.Quantity,
                entity.Status
            );
        }

        public static InventoryEntity ToEntity(this CreateInventoryCommand cmd)
        {
            return new InventoryEntity
            {
                ProductId = cmd.ProductId,
                WarehouseId = cmd.WarehouseId,
                Quantity = cmd.Quantity,
                Status = cmd.Status
            };
        }

        public static InventoryResponse ToResponse(this InventoryEntity entity)
        {
            return new InventoryResponse
            {
                Id = entity.Id,
                ProductId = entity.ProductId,
                WarehouseId = entity.WarehouseId,
                Quantity = entity.Quantity,
                Status = entity.Status
            };
        }

        public static InventoryEntity ToEntity(this UpdateInventoryCommand cmd)
        {
            return new InventoryEntity
            {
                Id = cmd.Id,
                ProductId = cmd.ProductId,
                WarehouseId = cmd.WarehouseId,
                Quantity = cmd.Quantity,
                Status = cmd.Status
            };
        }

        public static CreateInventoryCommand ToCreateCommand(this CreateInventoryDto dto)
        {
            return new CreateInventoryCommand
            {
                ProductId = dto.ProductId,
                WarehouseId = dto.WarehouseId,
                Quantity = dto.Quantity,
                Status = dto.Status
            };
        }

        public static UpdateInventoryCommand ToUpdateCommand(this UpdateInventoryDto dto)
        {
            return new UpdateInventoryCommand
            {
                Id = dto.id,
                ProductId = dto.ProductId,
                WarehouseId = dto.WarehouseId,
                Quantity = dto.Quantity,
                Status = dto.Status
            };
        }
    }
}
