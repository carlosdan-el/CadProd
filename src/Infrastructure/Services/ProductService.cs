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
                string query = "SELECT * FROM tbProduct WITH (NOLOCK)";
                var response = await connection.QueryAsync<Product>(query);
                return response.ToList();
            }
        }
    
        public async Task<Product> GetProductByIdAsync(string id)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = $"SELECT * FROM tbProduct WITH (NOLOCK) WHERE Id = {id}";
                var response = await connection.QueryFirstAsync<Product>(query);
                return response;
            }
        }
    
        public async Task<int> CreateProductAsync(Product product)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SPCreateProduct";
                var data = new {
                    Name = product.Name,
                    Description = product.Description,
                    CategoryId = product.CategoryId,
                    TypeId = product.TypeId,
                    SizeId = product.SizeId,
                    Price = product.Price,
                    Tags = product.Tags,
                    ImagePath = product.ImagePath,
                    CreatedBy = product.CreatedBy,
                    UpdatedBy = product.UpdatedBy
                };

                var result = await connection.ExecuteAsync(query, data, 
                commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    
        public async Task UpdateProductAsync(Product product)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                var query = "SPUpdateProduct";
                var data = new {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    CategoryId = product.CategoryId,
                    TypeId = product.TypeId,
                    SizeId = product.SizeId,
                    Price = product.Price,
                    Tags = product.Tags,
                    UpdatedBy = product.UpdatedBy
                };
                await connection.ExecuteAsync(query, data,
                commandType: CommandType.StoredProcedure);
            }
        }
    
        public async Task DeleteProductAsync(string id)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = $"DELETE FROM tbProduct WHERE Id = {id}";
                await connection.ExecuteAsync(query);
            }
        }

    }
}