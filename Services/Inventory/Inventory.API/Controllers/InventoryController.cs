using MediatR;
using Microsoft.AspNetCore.Mvc;
using Inventory.Application.Commands;
using Inventory.Application.DTOs;
using Inventory.Application.Mappers;
using Inventory.Application.Queries;

namespace Inventory.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class InventoryController : Controller
    {
        private readonly IMediator _mediator;

        public InventoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // https://localhost:7073/api/v1/Inventory
        [HttpGet]
        public async Task<ActionResult<List<InventoryDto>>> GetAllInventory()
        {
            var query = new GetAllInventoryQuery();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        // https://localhost:7073/api/v1/Inventory/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<InventoryDto>> GetInventoryById(int id)
        {
            var query = new GetInventoryByIdQuery(id);
            var result = await _mediator.Send(query);

            return Ok(result);
        }
        // https://localhost:7073/api/v1/Inventory/warehouse/{warehouseId}
        [HttpGet("warehouse/{warehouseId}")]
        public async Task<ActionResult<InventoryDto>> GetInventoryByWarehouseId(int warehouseId)
        {
            var query = new GetInventoryByWarehouseIdQuery(warehouseId);
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        // https://localhost:7073/api/v1/Inventory
        [HttpPost()]
        public async Task<ActionResult<InventoryDto>> CreateInventory(CreateInventoryDto dto)
        {
            var command = dto.ToCreateCommand();
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        // https://localhost:7073/api/v1/Inventory/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<InventoryDto>> UpdateInventory(int id, UpdateInventoryDto dto)
        {
            var command = dto.ToUpdateCommand();
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        // https://localhost:7073/api/v1/Inventory/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteInventory(int id)
        {
            var command = new DeleteInventoryByIdCommand { Id = id };
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
