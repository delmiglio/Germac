using MediatR;

namespace Germac.Application.Commands.DeletePartCommand
{
    public class DeletePartRequest(long id) : IRequest<DeletePartResponse>
    {
        public long Id { get; set; } = id;
    }
}
