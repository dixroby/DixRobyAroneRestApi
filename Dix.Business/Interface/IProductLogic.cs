using Dix.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dix.Business.Interface
{
    public interface IProductLogic
    {
        Task<int> AddAsync(Products entity);
        Task<int> DeleteAsync(int id);
        Task<IReadOnlyList<Products>> GetAllAsync();
        Task<Products> GetByIdAsync(int id);
        Task<int> UpdateAsync(Products entity);
    }
}