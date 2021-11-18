using Dix.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IProductRepository
    {
        Task<int> AddAsync(Products entity);
        Task<int> DeleteAsync(int id);
        Task<IReadOnlyList<Products>> GetAllAsync();
        Task<Products> GetByIdAsync(int id);
        Task<int> UpdateAsync(Products entity);
    }
}