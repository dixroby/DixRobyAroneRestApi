using Dix.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IProductRepository
    {
        Task<int> AddAsync(Product entity);
        Task<int> DeleteAsync(int id);
        Task<IReadOnlyList<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task<int> UpdateAsync(Product entity);
    }
}