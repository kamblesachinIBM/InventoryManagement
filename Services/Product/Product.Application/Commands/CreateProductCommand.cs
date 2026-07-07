using MediatR;
using Product.Application.Responses;

namespace Product.Application.Commands
{
    public record CreateProductCommand : IRequest<ProductResponse>
    {
        public string? Code { get; set; }    
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}
