using Germac.Application.Query.FindPartQuery;
using Germac.Domain.Repositories;
using Germac.Infrastructure.Queries;
using Germac.Infrastructure.Repositories;
using MediatR;

namespace Germac.Application.Query.FindPartQuery
{
    public class FindPartQuery : IRequestHandler<FindPartRequest, FindPartResponse>
    {
        private readonly IPartRepository _partRepository;
        public FindPartQuery(IPartRepository partRepository)
        {
            _partRepository = partRepository;
        }
        public async Task<FindPartResponse> Handle(FindPartRequest request, CancellationToken cancellationToken)
        {
            var part = await _partRepository.GetById(PartQueries.Find, request.Id);

            if (part != null)
            {
                return new FindPartResponse
                {
                    Id = part.Id,
                    Name = part.Name,
                    PartId = part.Id,
                    PartNumber = part.PartNumber,
                    Price = part.Price,
                    Quantity = part.Quantity
                };
            }

            return new FindPartResponse();
        }
    }
}
