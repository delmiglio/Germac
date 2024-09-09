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

            _logger.Information("Checking If Order Id Already Exists");

            var orderExistent = await _orderRepository.GetById(OrderQueries.FindByOrderId, request.OrderId);

            if (orderExistent != null)
            {
                _logger.Information("Order Id Already Exists. Id: {0}", orderExistent.Id);
                return new CreateOrderResponse
                {
                    Data = orderExistent,
                    Success = false,
                    ErrorMessage = "Order Already Exists",
                };
            }

            var order = new Order(request.OrderNumber, request.TotalPrice);
            var orderCreationResult = await _orderRepository.Add(OrderQueries.Insert, order);
            if (orderCreationResult <= 0)
            {
                _logger.Information("Order Not Created");
                return new CreateOrderResponse
                {
                    Success = false,
                    ErrorMessage = "Part Not Created",
                    Data = null
                };
            }

            _logger.Information("Order Created");
            _logger.Information($"Finishing Handler {nameof(CreatePartCommand)}");
            return new CreateOrderResponse
            {
                Success = true,
                Data = orderCreationResult,
                ErrorMessage = null,
            };
        }
    }
}
