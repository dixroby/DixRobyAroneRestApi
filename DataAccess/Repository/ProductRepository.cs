using Dapper;
using Dix.Dto;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    // servicio para realizar el crud de un producto
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<int> AddAsync(Products entity)
        {
            // En esta parte se agrega un producto
            const string sql = @"Insert into Products (Name,Price,Description) VALUES (@Name,@Price,@Description) ; SELECT SCOPE_IDENTITY()";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<int>(sql, entity);
                return result.Single(); 
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            const string sql = "DELETE FROM Products WHERE Id = @Id";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public async Task<IReadOnlyList<Products>> GetAllAsync()
        {
            const string sql = "SELECT * FROM Products";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<Products>(sql);
                return result.ToList();
            }
        }

        public async Task<Products> GetByIdAsync(int id)
        {
            const string sql = "SELECT * FROM Products WHERE Id = @Id";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Products>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<int> UpdateAsync(Products entity)
        {
            const string sql = "UPDATE Products SET Name = @Name, Price = @Price, Description = @Description WHERE Id = @Id";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}
