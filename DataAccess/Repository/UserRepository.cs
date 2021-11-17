using Dapper;
using DataAccess.Interface;
using Dix.Dto;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<int> AddAsync(User entity)
        {
            const string sql = "Insert into Users (Nombre,Apellidos,UserName,Password) VALUES (@Nombre,@Apellidos,@UserName,@Password)";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            const string sql = "DELETE FROM Users WHERE Id = @Id";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public async Task<IReadOnlyList<User>> GetAllAsync()
        {
            const string sql = "SELECT * FROM Users";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<User>(sql);
                return result.ToList();
            }
        }

        public async Task<User> GetByIdAsync(int id)
        {
            const string sql = "SELECT * FROM Users WHERE Id = @Id";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<User>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<int> UpdateAsync(User entity)
        {
            const string sql = "UPDATE Users SET Nombre = @Nombre, Apellidos = @Apellidos, UserName = @UserName, Password = @Password WHERE Id = @Id";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}
