using Germac.Domain.Entities;

namespace Germac.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> Get();
        Task<Order> Find(long id);
    }
}
