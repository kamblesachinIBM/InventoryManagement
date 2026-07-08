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
                entity.Code,
                entity.Name,
                entity.Quantity,
                entity.Location,
                entity.Status
            );
        }

        public static InventoryEntity ToEntity(this CreateInventoryCommand cmd)
        {
            return new InventoryEntity
            {
                Code = cmd.Code,
                Name = cmd.Name,
                Quantity = cmd.Quantity,
                Location = cmd.Location,
                Status = cmd.Status
            };
        }

        public static InventoryResponse ToResponse(this InventoryEntity entity)
        {
            return new InventoryResponse
            {
                Id = entity.Id,
                Code = entity.Code,
                Name = entity.Name,
                Quantity = entity.Quantity,
                Location = entity.Location,
                Status = entity.Status
            };
        }

        public static InventoryEntity ToEntity(this UpdateInventoryCommand cmd)
        {
            return new InventoryEntity
            {
                Id = cmd.Id,
                Code = cmd.Code,
                Name = cmd.Name,
                Quantity = cmd.Quantity,
                Location = cmd.Location,
                Status = cmd.Status
            };
        }

        public static CreateInventoryCommand ToCreateCommand(this CreateInventoryDto dto)
        {
            return new CreateInventoryCommand
            {
                Code = dto.Code,
                Name = dto.Name,
                Quantity = dto.Quantity,
                Location = dto.Location,
                Status = dto.Status
            };
        }

        public static UpdateInventoryCommand ToUpdateCommand(this UpdateInventoryDto dto)
        {
            return new UpdateInventoryCommand
            {
                Id = dto.id,
                Code = dto.Code,
                Name = dto.Name,
                Quantity = dto.Quantity,
                Location = dto.Location,
                Status = dto.Status
            };
        }
    }
}
