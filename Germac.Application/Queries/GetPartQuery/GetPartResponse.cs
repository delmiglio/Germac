using Germac.Application.DTO;

namespace Germac.Application.Queries.GetPartQuery
{
    public class GetPartResponse
    {
        public IEnumerable<PartDTO>? Parts { get; set; }
    }
}
