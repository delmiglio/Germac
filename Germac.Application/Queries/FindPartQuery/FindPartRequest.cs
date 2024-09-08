using Germac.Application.Queries.FindPartQuery;
using MediatR;

namespace Germac.Application.Queries.FindPartQuery
{
    public class FindPartRequest(long id) : IRequest<FindPartResponse>
    {
        public long Id { get; set; } = id;
    }
}
