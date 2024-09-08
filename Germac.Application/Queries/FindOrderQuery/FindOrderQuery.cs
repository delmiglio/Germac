using MediatR;

namespace Germac.Application.Query.FindOrder
{
    public class FindOrderQuery : IRequestHandler<FindOrderRequest, FindOrderResponse>
    {
        public Task<FindOrderResponse> Handle(FindOrderRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
