using Germac.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Germac.Infrastructure.Repositories
{
    internal class PartRepository
    {
        private readonly ConnectionFactory _connectionFactory;

        public OrderRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Part>> Get()
        {
            using (IDbConnection connection = _connectionFactory.Open())
            {
                string sql = "SELECT * FROM SomeTable";
                return await connection.QueryAsync<Part>(sql);
            }
        }

        public async Task<int> Create(Part entity)
        {
            using (IDbConnection connection = _connectionFactory.Open())
            {
                string sql = "INSERT INTO SomeTable (SomeColumn) VALUES (@SomeColumn)";
                return await connection.ExecuteAsync(sql, new { SomeColumn = entity.Name });
            }
        }
    }
}
