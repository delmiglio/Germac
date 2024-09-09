using Germac.Application.DTO;
using Germac.Domain.Repositories;
using Germac.Infrastructure.Queries;
using MediatR;

namespace Germac.Application.Queries.FindPartQuery
{
    public class FindPartQuery(IPartRepository partRepository) : IRequestHandler<FindPartRequest, FindPartResponse>
    {
        private readonly IPartRepository _partRepository = partRepository;

        public async Task<FindPartResponse> Handle(FindPartRequest request, CancellationToken cancellationToken)
        {
            var part = await _partRepository.GetById(PartQueries.Find, request.Id);

            if (part == null)
            {
                return new FindPartResponse
                {
                    Success = false,
                    ErrorMessage = "Part Not Found",
                    Data = null
                };
            }

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

