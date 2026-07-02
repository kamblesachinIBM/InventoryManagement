using MediatR;

namespace Warehouse.Application.DTOs
{
    public record class CreateWarehouseDto(
        string? Code,
        string? Name,
        string? Location,
        bool Status
        );
    
    public record class WarehouseDto(
        int id,
        string? Code,
        string? Name,
        string? Location,
        bool Status
        );

    public record class UpdateWarehouseDto(
        int id,
        string? Code,
        string? Name,
        string? Location,
        bool Status
        );
    
}
