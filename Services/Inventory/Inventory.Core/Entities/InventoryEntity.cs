namespace Inventory.Core.Entities
{
    public class InventoryEntity : EntityBase
    {
        public int ProductId { get; set; }
        public int WarehouseId { get; set; }
        public int Quantity { get; set; }
       
        public bool Status { get; set; }
    }
}
