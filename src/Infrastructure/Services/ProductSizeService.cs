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
    
        public async Task<ProductSize> GetProductSizeByIdAsync(string id)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = $"";
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
    }
}