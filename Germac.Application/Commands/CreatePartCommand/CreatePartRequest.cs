using Germac.Application.Command.CreatePartCommand;
using MediatR;

namespace Germac.Application.Commands.CreatePartCommand
{
    public class CreatePartRequest : IRequest<CreatePartResponse>
    {
        public long PartId { get; set; } // TODO: SELECT MAX ID FROM PART + 1
        public string? PartNumber { get; set; }
        public string? Name { get; set; }
        public long Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
