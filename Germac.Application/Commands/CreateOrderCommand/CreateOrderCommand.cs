using Germac.Domain.Entities;
using Germac.Domain.Repositories;
using Germac.Infrastructure.Queries;
using MediatR;
using Serilog;

namespace Germac.Application.Command.CreateOrderCommand
{
    public class CreateOrderCommand : IRequestHandler<CreateOrderRequest, CreateOrderResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger _logger;

        public CreateOrderCommand(IOrderRepository repository, ILogger logger)
        {
            _logger = logger;
            _orderRepository = repository;
        }

        public async Task<CreateOrderResponse> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            _logger.Information("Handling Create Order Request");
            var order = new Order(request.OrderNumber, request.TotalPrice);
            var orderCreated = await _orderRepository.Add(OrderQueries.Insert, order);
            return new CreateOrderResponse();
        }
    }
}
