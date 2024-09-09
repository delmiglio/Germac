using Germac.Application.Commands.DeletePartCommand;
using Germac.Application.Commands.CreatePartCommand;
using Germac.Application.Commands.UpdatePartCommand;
using Germac.Application.Queries.FindPartQuery;
using Germac.Application.Queries.GetPartQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Germac.Application.Base;
using Germac.Application.Commands.CreateOrderCommand;
using Germac.Application.Commands.DeleteOrderCommand;

namespace Germac.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PartController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetPart()
        {
            var request = new GetPartRequest();
            var parts = await _mediator.Send(request);

            if (parts == null)
            {
                return NotFound();
            }

            return Ok(parts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindPartById([FromRoute] long id)
        {
            var request = new FindPartRequest(id);
            var part = await _mediator.Send(request);

            if (part == null)
            {
                return NotFound(part);
            }

            return Ok(part);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePart([FromBody] CreatePartRequest request)
        {
            if (!ModelState.IsValid)
            {
                var errorResponse = new ApiResponse<object>
                {
                    Success = false,
                    ErrorMessage = "Invalid input data"
                };
                return BadRequest(errorResponse);
            }

            var partCreated = await _mediator.Send(request);
            return CreatedAtAction(nameof(CreatePartResponse), new { id = partCreated.Data }, partCreated);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePart([FromRoute] long id, [FromBody] UpdatePartRequest request)
        {
            if (!ModelState.IsValid)
            {
                var errorResponse = new ApiResponse<object>
                {
                    Success = false,
                    ErrorMessage = "Invalid input data"
                };
                return BadRequest(errorResponse);
            }

            request.Id = id;
            var orderUpdated = await _mediator.Send(request);

            if (orderUpdated == null)
            {
                return NotFound(orderUpdated);
            }

            return Ok(orderUpdated);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePart([FromRoute] long id)
        {
            var request = new DeleteOrderRequest(id);
            var order = await _mediator.Send(request);

            if (order == null)
            {
                return NotFound(order);
            }

            return NoContent();
        }
    }
}
