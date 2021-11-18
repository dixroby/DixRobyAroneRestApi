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
    public class BuyProductRepository : IBuyProductRepository
    {
        private readonly string _connectionString;

        public BuyProductRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<int> AddAsync(BuyProducts entity)
        {
            // En esta parte se agrega una compra y su detalle de compra de un usuario
            const string sql = @"Insert into BuyProducts (DateCreated,UserId) VALUES (@DateCreated,@UserId) ; SELECT SCOPE_IDENTITY()";
            const string sqlDetail = @"Insert into BuyProductDetails (Quantity,BuyProductId,ProductId) VALUES (@Quantity,@BuyProductId,@ProductId);";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = await connection.QueryAsync<int>(sql, entity);
                int buyProductId = result.Single();

                entity.BuyProductDetails.Select(x => x.BuyProductId = buyProductId).ToList();
                foreach (var item in entity.BuyProductDetails)
                {
                    await connection.QueryAsync<int>(sqlDetail, item);
                }
                return result.Single();
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            const string sql = "DELETE FROM BuyProducts WHERE Id = @Id;DELETE FROM BuyProductDetails WHERE BuyProductId = @Id";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public async Task<IReadOnlyList<BuyProducts>> GetAllAsync()
        {
            // En esta parte se obtiene la lista de compras, con sus productos
            const string sql = "SELECT * FROM BuyProducts";
            const string sqlDeatil = "SELECT * FROM BuyProductDetails WHERE BuyProductId IN @ids";
            const string sqlDeatilProduct = "SELECT * FROM Products WHERE id IN @listIdProduct";
            const string sqlUser = "SELECT * FROM Users WHERE id IN @listIdUsers";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<BuyProducts>(sql);
                var lisId = result.Select(x=>x.Id).ToList();
                var listIdUsers = result.Select(x=>x.UserId).ToList();

                var resultDetail = await connection.QueryAsync<BuyProductDetails>(sqlDeatil, new { ids = lisId });
                List<int> listIdProduct = resultDetail.Select(x=>x.ProductId).ToList();

                var resultDetailProduct = await connection.QueryAsync<Products>(sqlDeatilProduct, new { listIdProduct = listIdProduct });
                var resultUsers = await connection.QueryAsync<Users>(sqlUser, new { listIdUsers = listIdUsers });

                resultDetail.Select(x=>x.Product = resultDetailProduct.Where(p=>p.Id == x.ProductId).FirstOrDefault()).ToList();
                result.Select(x=>x.BuyProductDetails = resultDetail.Where(p=>p.BuyProductId == x.Id).ToList()).ToList();
                result.Select(x=>x.User = resultUsers.Where(p=>p.Id == x.UserId).FirstOrDefault()).ToList();

                return result.ToList();
            }
        }

        public async Task<BuyProducts> GetByIdAsync(int id)
        {
            const string sql = "SELECT * FROM BuyProducts WHERE Id = @Id";
            const string sqlDetail = "SELECT * FROM BuyProductDetails WHERE BuyProductId = @BuyProductId";
            const string sqlDeatilProduct = "SELECT * FROM Products WHERE id in @listIdProduct";
            const string sqlUser = "SELECT * FROM Users WHERE id = @UserId";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<BuyProducts>(sql, new { Id = id });
                var resultDetail = await connection.QueryAsync<BuyProductDetails>(sqlDetail, new { BuyProductId = result.Id });
                List<int> listIdProduct = resultDetail.Select(x => x.ProductId).ToList();
                var resultDetailProduct = await connection.QueryAsync<Products>(sqlDeatilProduct, new { listIdProduct = listIdProduct });

                var resultUsers = await connection.QueryAsync<Users>(sqlUser, new { UserId = result.UserId });

                resultDetail.Select(x => x.Product = resultDetailProduct.Where(p => p.Id == x.ProductId).FirstOrDefault()).ToList();
                result.User = resultUsers.FirstOrDefault();
                result.BuyProductDetails = resultDetail.ToList();

                return result;
            }
        }

        public async Task<int> UpdateAsync(BuyProducts entity)
        {
            const string sql = "UPDATE BuyProducts SET UserId = @UserId where Id = @Id";
            const string sqlDeleteDetail = @"DELETE FROM BuyProductDetails WHERE BuyProductId = @Id";
            const string sqlAddDetail = @"Insert into BuyProductDetails (Quantity,BuyProductId,ProductId) VALUES (@Quantity,@BuyProductId,@ProductId);";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                var resultDetail = await connection.ExecuteAsync(sqlDeleteDetail, new { Id = entity.Id });

                entity.BuyProductDetails.Select(x => x.BuyProductId = entity.Id).ToList();
                foreach (var item in entity.BuyProductDetails)
                {
                    await connection.QueryAsync<int>(sqlAddDetail, item);
                }

                return result;
            }
        }
    }
}
