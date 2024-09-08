using MediatR;

namespace Germac.Application.Command.CreateOrderCommand
{
    public class CreateOrderRequest : IRequest<CreateOrderResponse>
    {
        public long OrderId { get; set; } // TODO: SELECT MAX ID FROM Order + 1
        public long OrderNumber { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
