using MediatR;

namespace Germac.Application.Query.GetPart
{
    public class GetPartQuery : IRequestHandler<GetPartRequest, GetPartResponse>
    {
        public Task<GetPartResponse> Handle(GetPartRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
