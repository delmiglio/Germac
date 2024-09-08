using Germac.Application.Base;
using Germac.Application.DTO;

namespace Germac.Application.Queries.FindOrderQuery
{
    public class FindOrderResponse : ApiResponse<FindOrderResponse>
    {
        public OrderDTO? Order { get; set; }
    }
}
