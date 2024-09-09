using Germac.Application.DTO;
using Germac.Domain.Repositories;
using Germac.Infrastructure.Queries;
using MediatR;
using Serilog;

namespace Germac.Application.Queries.FindPartQuery
{
    public class FindPartQuery(IPartRepository _partRepository, ILogger logger) : IRequestHandler<FindPartRequest, FindPartResponse>
    {
        public async Task<FindPartResponse> Handle(FindPartRequest request, CancellationToken cancellationToken)
        {
            logger.Information($"Starting Query {nameof(FindPartQuery)}");
            var part = await _partRepository.GetById(PartQueries.FindById, request.Id);

            if (part == null)
            {
                logger.Information($"Finishing Query {nameof(FindPartQuery)}");
                return new FindPartResponse
                {
                    Success = false,
                    ErrorMessage = "Part Not Found",
                    Data = null
                };
            }
            logger.Information($"Finishing Query {nameof(FindPartQuery)}");
            return new FindPartResponse
            {
                Success = true,
                Data = new PartDTO
                {

                    Id = part.Id,
                    Name = part.Name,
                    PartId = part.Id,
                    PartNumber = part.PartNumber,
                    Price = part.Price,
                    Quantity = part.Quantity

                },
                ErrorMessage = null
            };

        }
    }
}

