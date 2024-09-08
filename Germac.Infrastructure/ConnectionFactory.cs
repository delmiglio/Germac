using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Germac.Infrastructure
{
    public class ConnectionFactory
    {
        private readonly string _connectionString;

        public ConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;

        }

        public IDbConnection Open()
        {
            return new MySqlConnection(_connectionString);
        }

    }
}
