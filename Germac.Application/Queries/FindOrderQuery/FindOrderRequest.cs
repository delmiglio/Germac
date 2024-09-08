using MediatR;

namespace Germac.Application.Query.FindOrder
{
    public class FindOrderRequest : IRequest<FindOrderResponse>
    {
        public FindOrderRequest(long id)
        {
            this.Id = id;
        }
        public long Id { get; set; }
    }
}
