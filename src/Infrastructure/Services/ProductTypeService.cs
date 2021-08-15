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

        public async Task<List<ProductType>> GetAllProductTypes()
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "";
                var response = await connection.QueryAsync<ProductType>(query);
                return response.ToList(); 
            }
        }
    
        public async Task<ProductType> GetProductTypeById(string id)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "";
                var response = await connection
                .QueryFirstAsync<ProductType>(query);
                return response;
            }
        }

        public async Task<List<ProductType>> GetProductTypesByCategoryId(string id)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = $"SELECT * FROM tbProductType WITH (NOLOCK) WHERE ProductCategoryId = {id}";
                var response = await connection.QueryAsync<ProductType>(query);
                return response.ToList();
            }
        }

        public async Task<int> CreateProductType(ProductType type)
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
    }
}