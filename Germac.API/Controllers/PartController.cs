using Germac.Application.Command.CreatePartCommand;
using Germac.Application.DTO;
using Germac.Application.Query.GetPart;
using Germac.Domain.Entities;
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
            var request = new FindPartRequest();
            var parts = await _mediator.Send(request);

            return Ok(parts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindPartById([FromRoute] long id)
        {
            var request = new FindPartRequest();
            var part = await _mediator.Send(request);

            return Ok(part);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePart([FromBody] DeletePartRequest request)
        {
            var partCreated = await _mediator.Send(request);
            return Ok(partCreated);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePart([FromRoute] long id, [FromBody] DeletePartRequest request)
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
