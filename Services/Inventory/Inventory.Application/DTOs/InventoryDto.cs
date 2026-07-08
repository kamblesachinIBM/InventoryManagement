namespace Inventory.Application.DTOs
{
    public record class CreateInventoryDto(
        string? Code,
        string? Name,
        int Quantity,
        string? Location,
        bool Status
        );

    public record class InventoryDto(
        int id,
        string? Code,
        string? Name,
        int Quantity,
        string? Location,
        bool Status
        );

    public record class UpdateInventoryDto(
        int id,
        string? Code,
        string? Name,
        int Quantity,
        string? Location,
        bool Status
        );

}
