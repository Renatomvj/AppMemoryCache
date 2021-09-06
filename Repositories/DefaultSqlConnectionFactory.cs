using AppMemoryCache.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AppMemoryCache.Repositories
{
    public class DefaultSqlConnectionFactory : IConnectionFactory
    {
        public string _connectionString { get; private set; }
        public DefaultSqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IDbConnection Connection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
