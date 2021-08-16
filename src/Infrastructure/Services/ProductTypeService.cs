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
    public class ProductTypeService
    {
        private readonly string _connectionString;

        public ProductTypeService(IConfiguration configuration)
        {
            _connectionString = configuration
            .GetConnectionString("DatabaseConnection");
        }

        public async Task<List<ProductType>> GetAllProductTypesAsync()
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM tbProductType WITH (NOLOCK)";
                var response = await connection.QueryAsync<ProductType>(query);
                return response.ToList(); 
            }
        }
    
        public async Task<List<ProductTypeReport>> GetAllProductTypesViewAsync()
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SPGetProductTypesView";
                var response = await connection.QueryAsync<ProductTypeReport>(query,
                commandType: CommandType.StoredProcedure);
                return response.ToList(); 
            }
        }
    
        public async Task<ProductType> GetProductTypeByIdAsync(string id)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = $"SELECT * FROM tbProductType WITH (NOLOCK) WHERE Id = {id}";
                var response = await connection
                .QueryFirstAsync<ProductType>(query);
                return response;
            }
        }

        public async Task<List<ProductType>> GetProductTypesByCategoryIdAsync(string id)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = $"SELECT * FROM tbProductType WITH (NOLOCK) WHERE ProductCategoryId = {id}";
                var response = await connection.QueryAsync<ProductType>(query);
                return response.ToList();
            }
        }

        public async Task<int> CreateProductTypeAsync(ProductType type)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SPCreateProductType";
                var data = new {
                    Name = type.Name,
                    Description = type.Description,
                    ProductCategoryId = type.ProductCategoryId,
                    CreatedBy = type.CreatedBy,
                    UpdatedBy = type.UpdatedBy
                };
                var response = await connection.ExecuteAsync(query, data,
                commandType: CommandType.StoredProcedure);
                return response;
            }
        }
    
        public async Task UpdateProducTypeAsync(ProductType type)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                var query = "SPUpdateProductType";
                var data = new {
                    Id = type.Id,
                    Name = type.Name,
                    ProductCategoryId = type.ProductCategoryId,
                    Description = type.Description,
                    UpdatedBy = type.UpdatedBy
                };
                await connection.ExecuteAsync(query, data,
                commandType: CommandType.StoredProcedure);
            }
        }
    
        public async Task DeleteProductTypeAsync(string id)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = $"DELETE FROM tbProductType WHERE Id = {id}";
                await connection.ExecuteAsync(query);
            }
        }
    
    }
}