using MediatR;

namespace Germac.Application.Command.UpdatePartCommand
{
    public class UpdatePartRequest : IRequest<UpdatePartResponse>
    {
        public long Id { get; set; }
        public long PartId { get; set; }
        public string PartNumber { get; set; }
        public string Name { get; set; }
        public long Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
