using Germac.Application.Commands.CreatePartCommand;
using Germac.Application.Commands.UpdatePartCommand;
using Germac.Application.Queries.FindPartQuery;
using Germac.Application.Queries.GetPartQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Germac.Application.Commands.DeleteOrderCommand;
using Germac.Application.Commands.DeletePartCommand;

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

            if (parts.Data == null)
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
            var partCreated = await _mediator.Send(request);
            return Created(partCreated.Data as string, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePart([FromRoute] long id, [FromBody] UpdatePartRequest request)
        {
            request.Id = id;
            var partUpdated = await _mediator.Send(request);

            if (partUpdated.Data == null)
            {
                return NotFound(partUpdated);
            }

            return Ok(partUpdated);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePart([FromRoute] long id)
        {
            var request = new DeletePartRequest(id);
            var part = await _mediator.Send(request);

            if (part.Data == null)
            {
                return NotFound(part);
            }

            return NoContent();
        }
    }
}
