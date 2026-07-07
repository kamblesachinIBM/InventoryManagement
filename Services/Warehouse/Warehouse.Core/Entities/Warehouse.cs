namespace Warehouse.Core.Entities
{
    public class WarehouseEntity : EntityBase
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public bool Status { get; set; }
    }
}
