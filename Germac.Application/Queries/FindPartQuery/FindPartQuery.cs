using MediatR;

namespace Germac.Application.Query.FindPartQuery
{
    public class FindPartQuery : IRequestHandler<FindPartRequest, FindPartResponse>
    {
        public Task<FindPartResponse> Handle(FindPartRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
