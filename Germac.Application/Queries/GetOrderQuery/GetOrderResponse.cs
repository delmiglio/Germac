using Germac.Application.DTO;

namespace Germac.Application.Query.GetOrder
{
    public class GetOrderResponse
    {
        public IEnumerable<OrderDTO> Orders { get; set; }
    }
}
