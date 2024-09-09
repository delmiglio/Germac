using Germac.Application.DTO;
using Germac.Domain.Repositories;
using Germac.Infrastructure.Queries;
using MediatR;
using Serilog;

namespace Germac.Application.Queries.FindOrderQuery
{
    public class FindOrderQuery(IOrderRepository _orderRepository, ILogger logger) : IRequestHandler<FindOrderRequest, FindOrderResponse>
    {
        public async Task<FindOrderResponse> Handle(FindOrderRequest request, CancellationToken cancellationToken)
        {
            logger.Information($"Starting Query {nameof(FindOrderQuery)}");
            var order = await _orderRepository.GetById(OrderQueries.FindById, request.Id);

            if (order == null)
            {
                logger.Information($"Finishing Query {nameof(FindOrderQuery)}");
                return new FindOrderResponse
                {
                    Data = null,
                    ErrorMessage = "Order Not Found",
                    Success = false,

                };
            }
            logger.Information($"Finishing Query {nameof(FindOrderQuery)}");
            return new FindOrderResponse
            {
                Success = true,
                ErrorMessage = null,
                Data = new OrderDTO
                {
                    OrderId = order.OrderId,
                    TotalPrice = order.TotalPrice,
                }
            };
        }
    }
}
