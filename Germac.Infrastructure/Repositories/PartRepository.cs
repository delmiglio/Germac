using Dapper;
using Germac.Domain.Entities;
using Germac.Domain.Repositories;
using System.Data;

namespace Germac.Infrastructure.Repositories
{
    public class PartRepository : IPartRepository
    {
        private readonly ConnectionFactory _connectionFactory;

        public PartRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Part>> Get()
        {
            using (IDbConnection connection = _connectionFactory.Open())
            {
                return await connection.QueryAsync<Part>("SELECT * FROM PART");
            }
        }

        public async Task<Part> Find(long id)
        {
            using (IDbConnection connection = _connectionFactory.Open())
            {
                return await connection.QueryFirstAsync<Part>("SELECT * FROM PART WHERE ID = @ID", new { id });
            }
        }
    }
}
