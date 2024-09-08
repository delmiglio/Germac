using Germac.Domain.Entities;
using Germac.Domain.Repositories;
using Germac.Infrastructure.UnitOfWork;

namespace Germac.Infrastructure.Repositories
{
    public class PartRepository : GenericRepository<Part>, IPartRepository
    { 
        public PartRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
