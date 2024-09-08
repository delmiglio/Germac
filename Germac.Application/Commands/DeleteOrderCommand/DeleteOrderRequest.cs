using MediatR;

namespace Germac.Application.Command.DeleteOrderCommand
{
    public class DeleteOrderRequest : IRequest<DeleteOrderResponse>
    {
        public DeleteOrderRequest(long id)
        {
            this.Id = id;
        }

        public long Id { get; set; }
    }
}
