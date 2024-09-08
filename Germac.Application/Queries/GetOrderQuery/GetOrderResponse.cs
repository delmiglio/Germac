using Germac.Application.Base;
using Germac.Application.DTO;

namespace Germac.Application.Queries.GetOrderQuery
{
    public class GetOrderResponse : ApiResponse<GetOrderResponse>
    {
        public IEnumerable<OrderDTO>? Orders { get; set; }
    }
}
