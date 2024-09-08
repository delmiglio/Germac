using MediatR;

namespace Germac.Application.Command.DeleteOrderCommand
{
    public class DeleteOrderCommand : IRequestHandler<DeleteOrderRequest, DeleteOrderResponse>
    {
        //private readonly IOrderRepository _OrderRepository;

        //public DeleteOrderCommand(IOrderRepository repository)
        //{
        //    _repository = repository;
        //}

        //public async Task<Order> Handle(DeleteOrderRequest request, CancellationToken cancellationToken)
        //{
        //    var Order = new Order
        //    {
        //        Name = request.Name,
        //        Price = request.Price
        //    };

        //    await _repository.AddAsync(product);
        //    return product;
        //}
        public Task<DeleteOrderResponse> Handle(DeleteOrderRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

}
