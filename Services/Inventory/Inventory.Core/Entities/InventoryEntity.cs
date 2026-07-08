namespace Inventory.Core.Entities
{
    public class InventoryEntity : EntityBase
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public int Quantity { get; set; }
        public string? Location { get; set; }
        public bool Status { get; set; }
    }
}
