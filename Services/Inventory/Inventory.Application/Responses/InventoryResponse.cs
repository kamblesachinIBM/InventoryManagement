namespace Inventory.Application.Responses
{
    public record InventoryResponse
    {
        public int Id { get; init; }
        public string? Code { get; init; }
        public string? Name { get; init; }
        public int Quantity { get; init; }
        public string? Location { get; init; }
        public bool Status { get; init; }
    }
}
