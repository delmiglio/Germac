using Germac.Domain.Entities;
using Germac.Domain.Repositories;
using Germac.Infrastructure.UnitOfWork;
using Serilog;

namespace Germac.Infrastructure.Repositories
{
    public class PartRepository(IUnitOfWork unitOfWork, ILogger logger) : GenericRepository<Part>(unitOfWork, logger), IPartRepository
    {
    }
}
