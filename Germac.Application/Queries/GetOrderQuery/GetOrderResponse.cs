using Germac.Application.DTO;

namespace Germac.Application.Query.GetOrderQuery
{
    public class GetOrderResponse
    {
        public IEnumerable<OrderDTO> Orders { get; set; }
    }
}
