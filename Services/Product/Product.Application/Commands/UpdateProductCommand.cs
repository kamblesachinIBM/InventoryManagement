using MediatR;
using Product.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Application.Commands
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}
