using MediatR;

namespace Germac.Application.Command.CreatePartCommand
{
    public class DeletePartRequest : IRequest<DeletePartResponse>
    {
        public DeletePartRequest(long id)
        {
            this.Id = id;
        }

        public long Id { get; set; }
    }
}
