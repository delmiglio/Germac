using MediatR;

namespace Germac.Application.Query.GetOrder
{
    public class GetOrderQuery : IRequestHandler<GetOrderRequest, GetOrderResponse>
    {
        public Task<GetOrderResponse> Handle(GetOrderRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
