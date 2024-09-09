using Germac.Application.DTO;
using Germac.Domain.Repositories;
using Germac.Infrastructure.Queries;
using MediatR;

namespace Germac.Application.Queries.FindOrderQuery
{
    public class FindOrderQuery(IOrderRepository orderRepository) : IRequestHandler<FindOrderRequest, FindOrderResponse>
    {
        private readonly IOrderRepository _orderRepository = orderRepository;

        public async Task<FindOrderResponse> Handle(FindOrderRequest request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetById(OrderQueries.Get, request.Id);
            if (order != null)
            {
                return new FindOrderResponse
                {
                    Order = new OrderDTO
                    {
                        OrderId = order.OrderId,
                        TotalPrice = order.TotalPrice,
                    } 
                };
            }
            return new FindOrderResponse();
        }
    }
}
