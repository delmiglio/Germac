using MediatR;

namespace Germac.Application.Queries.FindOrderQuery
{
    public class FindOrderRequest(long id) : IRequest<FindOrderResponse>
    {
        public long Id { get; set; } = id;
    }
}
