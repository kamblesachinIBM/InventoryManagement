using System.ComponentModel.DataAnnotations.Schema;

namespace Product.Core.Entities
{
    public class ProductEntity : EntityBase
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
    }
}
