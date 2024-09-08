using Germac.Application.DTO;
using Germac.Application.Query.GetPartQuery;
using Germac.Domain.Repositories;
using Germac.Infrastructure.Queries;
using MediatR;

namespace Germac.Application.Query.GetPartQuery
{
    public class GetPartQuery : IRequestHandler<GetPartRequest, GetPartResponse>
    {
        private readonly IPartRepository _partRepository;

        public GetPartQuery(IPartRepository partRepository)
        {
            _partRepository = partRepository;
        }

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
