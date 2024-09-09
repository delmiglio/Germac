using MediatR;

namespace Germac.Application.Commands.CreateOrderCommand
{
    public class CreateOrderRequest : IRequest<CreateOrderResponse>
    {
        public long OrderId { get; set; }
        public long OrderNumber { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
