using Germac.Domain.Entities;
using Germac.Domain.Repositories;
using Germac.Infrastructure.UnitOfWork;
using Serilog;


namespace Germac.Infrastructure.Repositories
{
    public class OrderRepository(IUnitOfWork unitOfWork, ILogger logger) : GenericRepository<Order>(unitOfWork, logger), IOrderRepository
    {
    }
}
