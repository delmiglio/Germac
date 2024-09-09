using Germac.Application.Commands.AddPartsOrder;
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

            if (order.Data == null)
            {
                return NotFound(order);
            }

            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request)
        {
            var orderCreated = await _mediator.Send(request);
            return Created(orderCreated.Data as string, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder([FromRoute] long id, [FromBody] UpdateOrderRequest request)
        {
            request.Id = id;
            var orderUpdated = await _mediator.Send(request);

            if (orderUpdated.Data == null)
            {
                return NotFound(orderUpdated);
            }

            return Ok(orderUpdated);

        }

        [HttpPut("{id}/Part")]
        public async Task<IActionResult> AddPartsOrder([FromRoute] long id, [FromBody] AddPartsOrderRequest request)
        {
            request.OrderId = id;
            var orderUpdated = await _mediator.Send(request);

            if (orderUpdated.Data == null)
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

            if (order.Data == null)
            {
                return NotFound(order);
            }

            return NoContent();
        }
    }
}
