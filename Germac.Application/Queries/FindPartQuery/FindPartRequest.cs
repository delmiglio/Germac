using MediatR;

namespace Germac.Application.Query.FindPartQuery
{
    public class FindPartRequest : IRequest<FindPartResponse>
    {
        public FindPartRequest(long id)
        {
            this.Id = id;
        }
        public long Id { get; set; }
    }
}
