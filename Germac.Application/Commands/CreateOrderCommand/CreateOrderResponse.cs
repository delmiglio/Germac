using Germac.Application.Base;

namespace Germac.Application.Command.CreateOrderCommand
{
    public class CreateOrderResponse : ApiResponse<CreateOrderResponse>
    {
        public long Id { get; set; }
    }
}
