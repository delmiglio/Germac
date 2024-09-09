using Germac.Application.Base;
using Germac.Application.Commands.CreateOrderCommand;
using Germac.Application.Commands.DeleteOrderCommand;
using Germac.Application.Commands.UpdateOrderCommand;
using Germac.Application.Queries.FindOrderQuery;
using Germac.Application.Queries.GetOrderQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Germac.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetOrder()
        {
            var request = new GetOrderRequest();
            var orders = await _mediator.Send(request);

            if (orders == null)
            {
                return NotFound(orders);
            }

            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindOrderById([FromRoute] long id)
        {
            var request = new FindOrderRequest(id);
            var order = await _mediator.Send(request);

            if (order == null)
            {
                return NotFound(order);
            }

            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request)
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

            var orderCreated = await _mediator.Send(request);
            return CreatedAtAction(nameof(CreateOrderResponse), new { id = orderCreated.Data }, orderCreated);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder([FromRoute] long id, [FromBody] UpdateOrderRequest request)
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
        public async Task<IActionResult> DeleteOrder([FromRoute] long id)
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
