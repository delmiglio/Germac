using Germac.Domain.Entities;
using Germac.Domain.Repositories;
using Germac.Infrastructure.UnitOfWork;
using Serilog;


namespace Germac.Infrastructure.Repositories
{
    public class PartOrderRepository(IUnitOfWork unitOfWork, ILogger logger) : GenericRepository<PartOrder>(unitOfWork, logger), IPartOrderRepository
    {

    }
}
