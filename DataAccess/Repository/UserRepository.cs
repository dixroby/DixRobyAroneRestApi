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

        public async Task<int> AddAsync(Users entity)
        {
            const string sql = "Insert into Users (FirstName,LastName,UserName,Password) VALUES (@FirstName,@LastName,@UserName,@Password)";
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

        public async Task<IReadOnlyList<Users>> GetAllAsync()
        {
            const string sql = "SELECT * FROM Users";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<Users>(sql);
                return result.ToList();
            }
        }

        public async Task<IReadOnlyList<Products>> GetProductAllAsync(int UsuarioId)
        {
            const string sql = "exec SP_LISTAR @UsuarioId";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<Products>(sql,new { UsuarioId= UsuarioId });
                return result.ToList();
            }
        }

        public async Task<Users> GetByIdAsync(int id)
        {
            const string sql = "SELECT * FROM Users WHERE Id = @Id";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Users>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<int> UpdateAsync(Users entity)
        {
            const string sql = "UPDATE Users SET FirstName = @FirstName, LastName = @LastName, UserName = @UserName, Password = @Password WHERE Id = @Id";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}
