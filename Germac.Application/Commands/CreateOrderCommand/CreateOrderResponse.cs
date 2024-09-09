using Germac.Application.Base;

namespace Germac.Application.Commands.CreateOrderCommand
{
    public class CreateOrderResponse : ApiResponse<CreateOrderResponse>
    {
        public long Id { get; set; }
    }
}
