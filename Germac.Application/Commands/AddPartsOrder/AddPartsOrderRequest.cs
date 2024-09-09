using Germac.Application.DTO;
using MediatR;

namespace Germac.Application.Commands.AddPartsOrder
{
    public class AddPartsOrderRequest : IRequest<AddPartsOrderResponse>
    {
        public long OrderId { get; set; }
        public required IEnumerable<OrderPartDTO> PartsOrdered { get; set; }
    }
}
