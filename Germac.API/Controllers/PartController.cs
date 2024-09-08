using Germac.Application.Command.CreatePartCommand;
using Germac.Application.Command.DeletePartCommand;
using Germac.Application.Command.UpdatePartCommand;
using Germac.Application.Query.FindPart;
using Germac.Application.Query.GetPart;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Germac.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PartController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PartController(IMediator mediator)
        {
            _mediator = mediator;
        }

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

            return Ok(part);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePart([FromBody] CreatePartRequest request)
        {
            var partCreated = await _mediator.Send(request);
            return Ok(partCreated);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePart([FromRoute] long id, [FromBody] UpdatePartRequest request)
        {
            var partUpdated = await _mediator.Send(request);
            return Ok(partUpdated);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePart([FromRoute] long id)
        {
            var request = new DeletePartRequest(id);
            var part = await _mediator.Send(request);

            return Ok(part);
        }
    }
}
