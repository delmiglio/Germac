using Germac.Application.DTO;

namespace Germac.Application.Query.GetPartQuery
{
    public class GetPartResponse
    {
        public IEnumerable<PartDTO> Parts { get; set; }
    }
}
