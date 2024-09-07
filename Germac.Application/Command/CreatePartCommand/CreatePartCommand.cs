using MediatR;

namespace Germac.Application.Command.CreatePartCommand
{
    public class CreatePartCommand : IRequestHandler<CreatePartRequest, CreatePartResponse>
    {
        public Task<CreatePartResponse> Handle(CreatePartRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
