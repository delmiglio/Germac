using MediatR;

namespace Germac.Application.Command.UpdatePartCommand
{
    public class UpdatePartCommand : IRequestHandler<UpdatePartRequest, UpdatePartResponse>
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
        public Task<UpdatePartResponse> Handle(UpdatePartRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

}
