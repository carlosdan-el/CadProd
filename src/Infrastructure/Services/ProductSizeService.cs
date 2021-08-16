using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Linq;
using Dapper;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Infrastructure.Services
{
    public class ProductSizeService
    {
        private readonly string _connectionString;

        public ProductSizeService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DatabaseConnection");
        }

        public async Task<List<ProductSize>> GetAllProductSizesAsync()
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM tbProductSize WITH (NOLOCK)";
                var response = await connection.QueryAsync<ProductSize>(query);
                return response.OrderBy(x => x.Name).ToList();
            }
        }
    
        public async Task<List<ProductSizeReport>> GetAllProductSizeViewAsync()
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SPGETProductSize";
                var response = await connection.QueryAsync<ProductSizeReport>(query,
                commandType: CommandType.StoredProcedure);
                return response.ToList();
            }
        }

        public async Task<ProductSize> GetProductSizeByIdAsync(string id)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = $"SELECT * FROM tbProductSize WITH (NOLOCK) WHERE Id = {id}";
                var response = await connection.QueryFirstAsync<ProductSize>(query);
                return response;
            }
        }
    
        public async Task<int> CreateProductSizeAsync(ProductSize size)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SPCreateProductSize";
                var data = new {
                    Name = size.Name,
                    Description = size.Description,
                    CreatedBy = size.CreatedBy,
                    UpdatedBy = size.UpdatedBy
                };
                var response = await connection.ExecuteAsync(query, data,
                commandType: CommandType.StoredProcedure);
                return response;
            }
        }
    
        public async Task UpdateProductSizeAsync(ProductSize size)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                var query = "SPUpdateProductSize";
                var data = new {
                    Id = size.Id,
                    Name = size.Name,
                    Description = size.Description,
                    UpdatedBy = size.UpdatedBy
                };

                await connection.ExecuteAsync(query, data,
                commandType: CommandType.StoredProcedure);
            }
        }
    
        public async Task DeleteProductSizeAsync(string id)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = $"DELETE FROM tbProductSize WHERE Id = {id}";
                await connection.ExecuteAsync(query);
            }
        }

    }
}