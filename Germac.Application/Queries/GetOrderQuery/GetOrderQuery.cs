using Germac.Application.DTO;
using Germac.Application.Queries.GetOrderQuery;
using Germac.Domain.Repositories;
using Germac.Infrastructure.Queries;
using MediatR;

namespace Germac.Application.Queries.GetOrderQuery
{
    public class GetOrderQuery(IOrderRepository orderRepository) : IRequestHandler<GetOrderRequest, GetOrderResponse>
    {
        private readonly IOrderRepository _orderRepository = orderRepository;

        public async Task<GetOrderResponse> Handle(GetOrderRequest request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetAll(OrderQueries.Get);
            return new GetOrderResponse
            {
                Data = orders.Select(order => new OrderDTO
                {
                    CreateDate = order.CreateDate,
                    OrderId = order.Id,
                    TotalPrice = order.TotalPrice
                }),
                Success = true,
                ErrorMessage = null
            };
        }
    }
}
