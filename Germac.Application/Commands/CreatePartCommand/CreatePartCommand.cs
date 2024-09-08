using Germac.Application.Command.CreatePartCommand;
using Germac.Domain.Entities;
using Germac.Domain.Repositories;
using Germac.Infrastructure.Queries;
using MediatR;
using Serilog;

namespace Germac.Application.Commands.CreatePartCommand
{
    public class CreatePartCommand(IPartRepository repository, ILogger logger) : IRequestHandler<CreatePartRequest, CreatePartResponse>
    {
        private readonly IPartRepository _partRepository = repository;
        private readonly ILogger _logger = logger;

        public async Task<CreatePartResponse> Handle(CreatePartRequest request, CancellationToken cancellationToken)
        {
            _logger.Information($"Starting Handler {nameof(CreatePartCommand)}");

            var part = new Part(request.PartId, request.PartNumber, request.Name, request.Quantity, request.Price)
            {
                CreateDate = DateTime.Now
            };

            var partCreated = await _partRepository.Add(PartQueries.Insert, part);

            _logger.Information($"Finishing Handler {nameof(CreatePartCommand)}");
            return new CreatePartResponse();
        }
    }

}
