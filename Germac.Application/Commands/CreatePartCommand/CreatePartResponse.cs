using Germac.Application.Base;

namespace Germac.Application.Command.CreatePartCommand
{
    public class CreatePartResponse : ApiResponse<CreatePartResponse>
    {
        public long Id { get; set; }
    }
}
