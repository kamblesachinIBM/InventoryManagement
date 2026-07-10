using MediatR;
using Microsoft.AspNetCore.Mvc;
using Product.Application.Commands;
using Product.Application.DTOs;
using Product.Application.Mappers;
using Product.Application.Queries;

namespace Product.API.Controllers
{
    /// <summary>
    /// Represents the ProductController class that handles product-related API requests.
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController : Controller
    {

        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductController"/> class.
        /// </summary>
        /// <param name="mediator"></param>
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Handles the HTTP GET request to retrieve all products.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetAllProducts()
        {
            var query = new GetAllProductQuery();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            var query = new GetProductByIdQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateProduct(CreateProductDto createProductDto)
        {
            var command = createProductDto.ToCreateProductCommand();
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<ProductDto>> UpdateProduct(UpdateProductDto updateProductDto)
        {
            var command = updateProductDto.ToUpdateProductCommand();
            var result = await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var command = new DeleteProductByIdCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
