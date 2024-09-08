using Germac.Domain.Entities;
using Germac.Domain.Repositories;
using MediatR;

namespace Germac.Application.Command.CreatePartCommand
{
    public class CreatePartCommand : IRequestHandler<CreatePartRequest, CreatePartResponse>
    {
        private readonly IPartRepository _partRepository;

        public CreatePartCommand(IPartRepository repository)
        {
            _partRepository = repository;
        }

        public async Task<CreatePartResponse> Handle(CreatePartRequest request, CancellationToken cancellationToken)
        {
            //var part = new Part(request.PartId, request.PartNumber, request.Name, request.Quantity, request.Price);
            //var partCreated = await _partRepository.Create(part);
            //if (partCreated != null) {
            //    return new CreatePartResponse
            //    {
            //        Id = partCreated.Id
            //    };
            //}

            //return null;
            throw new NotImplementedException();
        }
    }

}
