using Germac.Domain.Repositories;
using Germac.Infrastructure.Queries;
using MediatR;

namespace Germac.Application.Command.DeleteOrderCommand
{
    public class DeleteOrderCommand : IRequestHandler<DeleteOrderRequest, DeleteOrderResponse>
    {
        private readonly IOrderRepository _orderRepository;
        public DeleteOrderCommand(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<DeleteOrderResponse> Handle(DeleteOrderRequest request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetById(OrderQueries.Get, request.Id);

            if (order == null)
            {
                return null;
            }
            var orderDeleted = await _orderRepository.Delete(OrderQueries.Delete, order.Id);
            return new DeleteOrderResponse();
        }
    }

}
