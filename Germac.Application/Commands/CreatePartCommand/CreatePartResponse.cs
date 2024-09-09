using Germac.Application.Base;

namespace Germac.Application.Commands.CreatePartCommand
{
    public class CreatePartResponse : ApiResponse<CreatePartResponse>
    {
        public long Id { get; set; }
    }
}
