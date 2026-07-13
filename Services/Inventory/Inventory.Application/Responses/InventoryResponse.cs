namespace Inventory.Application.Responses
{
    public record InventoryResponse
    {
        public int Id { get; init; }
        public int? ProductId { get; set; }
        public int? WarehouseId { get; set; }
        public int? Quantity { get; set; }
        public bool Status { get; init; }
    }
}
