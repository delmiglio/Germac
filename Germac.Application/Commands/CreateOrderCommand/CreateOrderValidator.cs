using FluentValidation;
using Germac.Application.Command.CreateOrderCommand;

namespace Germac.Application.Commands.CreateOrderCommand
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderRequest>
    {
        public CreateOrderValidator()
        {
            RuleFor(x => x.OrderNumber).NotEmpty();
            RuleFor(x => x.TotalPrice).GreaterThan(0);
        }
    }
}
