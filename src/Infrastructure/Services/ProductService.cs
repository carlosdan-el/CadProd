using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Services
{
    public class ProductService
    {
        private readonly string _connectionString;

        public ProductService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DatabaseConnection");
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "";
                var response = await connection.QueryAsync<Product>(query);
                return response.ToList();
            }
        }
    
        public async Task<Product> GetProductByIdAsync(string id)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "";
                var response = await connection.QueryFirstAsync<Product>(query);
                return response;
            }
        }
    
        public async Task<int> CreateProductAsync(Product product)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SPCreateProduct";
                var result = await connection.ExecuteAsync(query, product, 
                commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}