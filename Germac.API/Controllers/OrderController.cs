using Germac.Application.Command.CreateOrderCommand;
using Germac.Application.Command.DeleteOrderCommand;
using Germac.Application.Command.UpdateOrderCommand;
using Germac.Application.Query.FindOrder;
using Germac.Application.Query.GetOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Germac.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrder()
        {
            var request = new GetOrderRequest();
            var Orders = await _mediator.Send(request);

            if (Orders == null)
            {
                return NotFound();
            }

            return Ok(Orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindOrderById([FromRoute] long id)
        {
            var request = new FindOrderRequest(id);
            var Order = await _mediator.Send(request);

            return Ok(Order);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request)
        {
            var OrderCreated = await _mediator.Send(request);
            return Ok(OrderCreated);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder([FromRoute] long id, [FromBody] UpdateOrderRequest request)
        {
            var OrderUpdated = await _mediator.Send(request);
            return Ok(OrderUpdated);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder([FromRoute] long id)
        {
            var request = new DeleteOrderRequest(id);
            var Order = await _mediator.Send(request);

            return Ok(Order);
        }
    }
}
