using MediatR;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Application.Commands;
using Warehouse.Application.DTOs;
using Warehouse.Application.Mappers;
using Warehouse.Application.Queries;

namespace Warehouse.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class WarehouseController : Controller
    {
        private readonly IMediator _mediator;

        public WarehouseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // https://localhost:7072/api/v1/Warehouse
        [HttpGet]
        public async Task<ActionResult<List<WarehouseDto>>> GetAllWarehouse()
        {
            var query = new GetAllWarehouseQuery();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        // https://localhost:7072/api/v1/Warehouse/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<WarehouseDto>> GetWarehouseById(int id)
        {
            var query = new GetWarehouseByIdQuery(id);
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        // https://localhost:7072/api/v1/Warehouse
        [HttpPost()]
        public async Task<ActionResult<WarehouseDto>> CreateWarehouse(CreateWarehouseDto dto)
        {
            var command = dto.ToCreateCommand();
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        // https://localhost:7072/api/v1/Warehouse/
        [HttpPut]
        public async Task<ActionResult<WarehouseDto>> UpdateWarehouse(UpdateWarehouseDto dto)
        {
            var command = dto.ToUpdateCommand();
            var result = await _mediator.Send(command);

            return Ok();
        }

        // https://localhost:7072/api/v1/Warehouse/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> CreateWarehouse(int id)
        {
            var command = new DeleteWarehouseByIdCommand(id);
            var result = await _mediator.Send(command);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}