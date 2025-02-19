﻿using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Dapper;
using Domain.Entities;
using System.Data;

namespace Infrastructure.Services
{
    public class ProductCategoryService
    {
        private readonly string _connectionString;

        public ProductCategoryService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DatabaseConnection");
        }

        public async Task<List<ProductCategory>> GetAllProductsCategoriesAsync()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM tbProductCategory WITH (NOLOCK)";
                var response = await connection.QueryAsync<ProductCategory>(query);
                return response.ToList();
            }
        }

        public async Task<ProductCategory> GetProductCategoryByIdAsync(string id)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = $"SELECT * FROM tbProductCategory WITH (NOLOCK) WHERE Id = {id}";
                var response = await connection.QueryFirstAsync<ProductCategory>(query);
                return response;
            }
        }
    
        public async Task<List<ProductTypeReport>> GetAllGetProductCategoryViewAsync()
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SPGetProductCategoriesView";
                var response = await connection.QueryAsync<ProductTypeReport>(query,
                commandType: CommandType.StoredProcedure);
                return response.ToList();
            }
        }

        public async Task<int> CreateCategoryAsync(ProductCategory category)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SPCreateCategory";
                var data = new {
                    Name = category.Name,
                    Description = category.Description,
                    CreatedBy = category.CreatedBy,
                    UpdatedBy = category.UpdatedBy
                };
                var response = await connection.ExecuteAsync(query, data,
                commandType: CommandType.StoredProcedure);
                return response;
            }
        }
    
        public async Task UpdateCategoryProductAsync(ProductCategory category)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                var query = "SPUpdateCategoryProduct";
                var data = new {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description,
                    UpdatedBy = category.UpdatedBy
                };
                await connection.ExecuteAsync(query, data,
                commandType: CommandType.StoredProcedure);
            }
        }
    
        public async Task DeleteCategoryProductAsync(string id)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = $"DELETE FROM tbProductCategory WHERE Id = {id}";
                await connection.ExecuteAsync(query);
            }
        }
        
    }
}
