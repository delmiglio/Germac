using Germac.Application.DTO;
using Germac.Domain.Repositories;
using Germac.Infrastructure.Queries;
using MediatR;

namespace Germac.Application.Queries.GetPartQuery
{
    public class GetPartQuery(IPartRepository partRepository) : IRequestHandler<GetPartRequest, GetPartResponse>
    {
        private readonly IPartRepository _partRepository = partRepository;

        public async Task<GetPartResponse> Handle(GetPartRequest request, CancellationToken cancellationToken)
        {
            var Parts = await _partRepository.GetAll(PartQueries.Get);
            return new GetPartResponse
            {
                Parts = Parts.Select(Part => new PartDTO
                {
                    Quantity = Part.Quantity,
                    Price = Part.Price,
                    PartNumber = Part.PartNumber,
                    PartId = Part.PartId,
                    Name = Part.Name,
                    Id = Part.Id
                })
            };
        }
    }
}
