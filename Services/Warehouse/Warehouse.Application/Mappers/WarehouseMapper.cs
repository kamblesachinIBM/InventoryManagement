using Warehouse.Application.Commands;
using Warehouse.Application.DTOs;
using Warehouse.Application.Responses;
using Warehouse.Core.Entities;

namespace Warehouse.Application.Mappers
{
    public static class WarehouseMapper
    {
        public static WarehouseDto ToDto(this WarehouseEntity entity)
        {
            return new WarehouseDto(
                entity.Id,
                entity.Code,
                entity.Name,
                entity.Location,
                entity.Status
            );
        }

        public static WarehouseEntity ToEntity(this CreateWarehouseCommand cmd)
        {
            return new WarehouseEntity
            {
                Code = cmd.Code,
                Name = cmd.Name,
                Location = cmd.Location,
                Status = cmd.Status
            };
        }

        public static WarehouseResponse ToResponse(this WarehouseEntity entity)
        {
            return new WarehouseResponse
            {
                Id = entity.Id,
                Code = entity.Code,
                Name = entity.Name,
                Location = entity.Location,
                Status = entity.Status
            };
        }

        public static WarehouseEntity ToEntity(this UpdateWarehouseCommand cmd)
        {
            return new WarehouseEntity
            {
                Id = cmd.Id,
                Code = cmd.Code,
                Name = cmd.Name,
                Location = cmd.Location,
                Status = cmd.Status
            };
        }
        public static List<WarehouseResponse> ToDtoList(this IEnumerable<WarehouseEntity> cmdList)
        {
            return cmdList.Select(cmd => new WarehouseResponse
            {
                Code = cmd.Code,
                Id = cmd.Id,
                Location = cmd.Location,
                Name = cmd.Name,
                Status = cmd.Status
            }).ToList(); 
        }

        public static CreateWarehouseCommand ToCreateCommand(this CreateWarehouseDto dto)
        {
            return new CreateWarehouseCommand
            {
                Code = dto.Code,
                Name = dto.Name,
                Location = dto.Location,
                Status = dto.Status
            };
        }
        public static UpdateWarehouseCommand ToUpdateCommand(this UpdateWarehouseDto dto)
        {
            return new UpdateWarehouseCommand
            {
                Id = dto.id,
                Code = dto.Code,
                Name = dto.Name,
                Location = dto.Location,
                Status = dto.Status
            };
        }
    }
}