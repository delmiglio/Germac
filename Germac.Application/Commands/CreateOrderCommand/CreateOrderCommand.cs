using Germac.Application.Command.CreateOrderCommand;
using Germac.Domain.Entities;
using Germac.Domain.Repositories;
using Germac.Infrastructure.Queries;
using MediatR;
using Serilog;

namespace Germac.Application.Commands.CreateOrderCommand
{
    public class CreateOrderCommand(IOrderRepository repository, ILogger logger) : IRequestHandler<CreateOrderRequest, CreateOrderResponse>
    {
        private readonly IOrderRepository _orderRepository = repository;
        private readonly ILogger _logger = logger;

        public async Task<CreateOrderResponse> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            _logger.Information($"Starting Handler {nameof(CreatePartCommand)}");

            var order = new Order(request.OrderNumber, request.TotalPrice);
            var orderCreated = await _orderRepository.Add(OrderQueries.Insert, order);

            _logger.Information("Order Created");
            _logger.Information($"Finishing Handler {nameof(CreatePartCommand)}");
            return new CreateOrderResponse();
        }
    }
}
