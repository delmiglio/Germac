using Germac.Domain.Entities;
using Germac.Domain.Repositories;
using Germac.Infrastructure.Queries;
using MediatR;

namespace Germac.Application.Command.CreateOrderCommand
{
    public class CreateOrderCommand : IRequestHandler<CreateOrderRequest, CreateOrderResponse>
    {
        private readonly IOrderRepository _orderRepository;

        public CreateOrderCommand(IOrderRepository repository)
        {
            _orderRepository = repository;
        }

        public async Task<CreateOrderResponse> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            var order = new Order(request.OrderNumber, request.TotalPrice);
            var orderCreated = await _orderRepository.Add(OrderQueries.Insert, order);
            return new CreateOrderResponse();
        }


   }

}
