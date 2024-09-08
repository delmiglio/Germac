using Germac.Domain.Entities;
using Germac.Domain.Repositories;
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
            //var Order = new Order(request.OrderId, request.OrderNumber, request.Price);
            //var OrderCreated = await _orderRepository.Create(Order);
            //if (OrderCreated != null) {
            //    return new CreateOrderResponse
            //    {
            //        Id = OrderCreated.Id
            //    };
            //}

            //return null;

            throw new NotImplementedException();
        }
    }

}
