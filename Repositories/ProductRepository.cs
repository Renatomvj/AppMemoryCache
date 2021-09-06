using AppMemoryCache.Core.Entities;
using AppMemoryCache.Core.Interfaces;
using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppMemoryCache.Repositories
{
    public class ProductRepository :  IProductRepository
    {                
        public readonly IConnectionFactory _connectionFactory;
        public ProductRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;            
        }
        public void Create(Product product)
        {
            using var connection = _connectionFactory.Connection();

            connection.Execute(@"INSERT INTO Product (Name) VALUES (@Name);", product);
        }
        public Product FindById(int id)
        {
            using var connection = _connectionFactory.Connection();

            return connection.Query<Product>($"SELECT Id, Name FROM Product where Id = {id}").FirstOrDefault();            
        }
        public IEnumerable<Product> GetAll()
        {
            using var connection = _connectionFactory.Connection();

            return connection.Query<Product>("SELECT Id, Name FROM Product;");
        }     
    }
}
