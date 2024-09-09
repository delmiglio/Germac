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

            _logger.Information("Checking If Part Id Already Exists");

            var partExistent = await _partRepository.GetById(PartQueries.FindById, request.PartId);
            
            if (partExistent != null)
            {
                _logger.Information("Part Id Already Exists. Id: {0}", partExistent.Id);
                return new CreatePartResponse
                {
                    Data = partExistent,
                    Success = false,
                    ErrorMessage = "Part Already Exists"
                };
            }

            var part = new Part(request.PartId, request.PartNumber, request.Name, request.Quantity, request.Price)
            {
                CreateDate = DateTime.Now
            };

            var partCreationResult = await _partRepository.Add(PartQueries.Insert, part);
            if(partCreationResult <= 0)
            {
                _logger.Information("Part Not Created");
                return new CreatePartResponse
                {
                    Success = false,
                    ErrorMessage = "Part Not Created",
                    Data = null
                };
            }
            
            _logger.Information($"Finishing Handler {nameof(CreatePartCommand)}");
            _logger.Information("Part Created");
            return new CreatePartResponse
            {
                Success = true,
                Data = partCreationResult,
                ErrorMessage = null
            };
        }
    }
}
