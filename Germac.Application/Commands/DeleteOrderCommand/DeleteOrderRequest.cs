using MediatR;

namespace Germac.Application.Commands.DeleteOrderCommand
{
    public class DeleteOrderRequest(long id) : IRequest<DeleteOrderResponse>
    {
        public long Id { get; set; } = id;
    }
}
