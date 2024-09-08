using Germac.Application.Base;
using Germac.Application.DTO;

namespace Germac.Application.Queries.FindPartQuery
{
    public class FindPartResponse : ApiResponse<FindPartResponse>
    {
        public PartDTO? Part { get; set; }
    }
}
