using MediatR;

namespace Germac.Application.Command.UpdateOrderCommand
{
    public class UpdateOrderCommand : IRequestHandler<UpdateOrderRequest, UpdateOrderResponse>
    {
        //private readonly IPartRepository _partRepository;

        //public UpdatePartCommand(IPartRepository repository)
        //{
        //    _repository = repository;
        //}

        //public async Task<Part> Handle(UpdatePartRequest request, CancellationToken cancellationToken)
        //{
        //    var part = new Part
        //    {
        //        Name = request.Name,
        //        Price = request.Price
        //    };

        //    await _repository.AddAsync(product);
        //    return product;
        //}
        public Task<UpdateOrderResponse> Handle(UpdateOrderRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

}
