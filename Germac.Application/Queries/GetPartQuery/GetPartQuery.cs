using Germac.Application.DTO;
using Germac.Domain.Repositories;
using Germac.Infrastructure.Queries;
using MediatR;
using Serilog;

namespace Germac.Application.Queries.GetPartQuery
{
    public class GetPartQuery(IPartRepository _partRepository, ILogger logger) : IRequestHandler<GetPartRequest, GetPartResponse>
    {
        public async Task<GetPartResponse> Handle(GetPartRequest request, CancellationToken cancellationToken)
        {
            logger.Information($"Starting Query {nameof(GetPartQuery)}");
            var parts = await _partRepository.GetAll(PartQueries.Get);

            logger.Information($"Finishing Query {nameof(GetPartQuery)}");
            var partsDto = parts.Select(Part => new PartDTO
            {
                Quantity = Part.Quantity,
                Price = Part.Price,
                PartNumber = Part.PartNumber,
                PartId = Part.PartId,
                Name = Part.Name,
                Id = Part.Id
            });

            return new GetPartResponse
            {
                Success = true,
                Data = partsDto,
                ErrorMessage = null
            };
        }
    }
}
