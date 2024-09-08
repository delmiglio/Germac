using Germac.Application.DTO;
using Germac.Domain.Repositories;
using Germac.Infrastructure.Queries;
using MediatR;

namespace Germac.Application.Query.GetOrderQuery
{
    public class GetOrderQuery : IRequestHandler<GetOrderRequest, GetOrderResponse>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderQuery(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<GetOrderResponse> Handle(GetOrderRequest request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetAll(OrderQueries.Get);
            return new GetOrderResponse
            {
                Orders = orders.Select(order => new OrderDTO
                {
                    CreateDate = order.CreateDate,
                    OrderId = order.Id,
                    TotalPrice = order.TotalPrice
                })
            };
        }
    }
}
