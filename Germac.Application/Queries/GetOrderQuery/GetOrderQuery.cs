using Germac.Application.DTO;
using Germac.Domain.Repositories;
using Germac.Infrastructure.Queries;
using MediatR;
using Serilog;

namespace Germac.Application.Queries.GetOrderQuery
{
    public class GetOrderQuery(IOrderRepository _orderRepository, ILogger logger) : IRequestHandler<GetOrderRequest, GetOrderResponse>
    {
        public async Task<GetOrderResponse> Handle(GetOrderRequest request, CancellationToken cancellationToken)
        {
            logger.Information($"Starting Query {nameof(GetOrderQuery)}");
            var orders = await _orderRepository.GetAll(OrderQueries.Get);
            logger.Information($"Finishing Query {nameof(GetOrderQuery)}");
            return new GetOrderResponse
            {
                Data = orders.Select(order => new OrderDTO
                {
                    Id = order.Id,
                    CreateDate = order.CreateDate,
                    OrderId = order.OrderId,
                    TotalPrice = order.TotalPrice
                }),
                Success = true,
                ErrorMessage = null
            };
        }
    }
}
