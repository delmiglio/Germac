﻿using MediatR;

namespace Germac.Application.Commands.UpdateOrderCommand
{
    public class UpdateOrderRequest : IRequest<UpdateOrderResponse>
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
