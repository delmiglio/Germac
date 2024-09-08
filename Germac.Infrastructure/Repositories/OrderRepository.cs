using Dapper;
using Germac.Domain.Entities;
using Germac.Domain.Repositories;
using System.Data;

namespace Germac.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ConnectionFactory _connectionFactory;

        public OrderRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Order>> Get()
        {
            using (IDbConnection connection = _connectionFactory.Open())
            {
                return await connection.QueryAsync<Order>("SELECT * FROM ORDER");
            }
        }

        public async Task<Order> Find(long id)
        {
            using (IDbConnection connection = _connectionFactory.Open())
            {
                return await connection.QueryFirstAsync<Order>("SELECT * FROM ORDER WHERE ID = @ID", new { id });
            }
        }

    }
}
