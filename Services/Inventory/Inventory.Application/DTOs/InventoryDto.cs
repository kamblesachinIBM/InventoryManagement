namespace Inventory.Application.DTOs
{
    public record class CreateInventoryDto(
       int ProductId,
        int WarehouseId,
        int Quantity,
        bool Status
        );

    public record class InventoryDto(
        int id,
        int ProductId,
        int WarehouseId,
        int Quantity,
       bool Status
        );

    public record class UpdateInventoryDto(
        int id,
        int ProductId,
        int WarehouseId,
        int Quantity,
        bool Status
        );

}
