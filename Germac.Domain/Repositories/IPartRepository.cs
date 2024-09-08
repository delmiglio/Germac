using Germac.Domain.Entities;

namespace Germac.Domain.Repositories
{
    public interface IPartRepository
    {
        Task<IEnumerable<Part>> Get();
        Task<Part> Find(long id);
    }
}
