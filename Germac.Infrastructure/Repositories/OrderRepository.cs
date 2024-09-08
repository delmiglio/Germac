using Germac.Domain.Entities;
using Germac.Domain.Repositories;
using Germac.Infrastructure.UnitOfWork;

namespace Germac.Infrastructure.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public string QueryGet = "SELECT * FROM ORDER";
        public string QueryFind = "SELECT * FROM ORDER WHERE ID = @ID";
        public string QueryUpdate = "UPDATE ORDER SET ";
        public string QueryDelete = "DELETE FROM ORDER WHERE ID = @ID";

        public OrderRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
