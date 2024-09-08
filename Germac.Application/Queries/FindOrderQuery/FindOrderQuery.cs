using Germac.Domain.Repositories;
using Germac.Infrastructure.Queries;
using MediatR;

namespace Germac.Application.Query.FindOrderQuery
{
    public class FindOrderQuery : IRequestHandler<FindOrderRequest, FindOrderResponse>
    {
        private readonly IOrderRepository _orderRepository;
        public FindOrderQuery(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<FindOrderResponse> Handle(FindOrderRequest request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetById(OrderQueries.Get, request.Id);
            if (order != null)
            {
                return new FindOrderResponse
                {
                    OrderId = order.OrderId,
                    TotalPrice = order.TotalPrice,
                };
            }
            return new FindOrderResponse();
        }
    }
}
