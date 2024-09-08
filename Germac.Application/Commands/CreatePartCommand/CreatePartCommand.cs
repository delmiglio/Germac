using MediatR;

namespace Germac.Application.Command.CreatePartCommand
{
    public class DeletePartCommand : IRequestHandler<DeletePartRequest, DeletePartResponse>
    {
        private readonly IPartRepository _partRepository;

        public DeletePartCommand(IPartRepository repository)
        {
            _repository = repository;
        }

        public async Task<Part> Handle(DeletePartRequest request, CancellationToken cancellationToken)
        {
            var part = new Part
            {
                Name = request.Name,
                Price = request.Price
            };

            await _repository.AddAsync(product);
            return product;
        }
        public Task<DeletePartResponse> Handle(DeletePartRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

}
