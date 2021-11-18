using Dix.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dix.Business.Interface
{
    public interface IUserLogic
    {
        Task<int> AddAsync(Users entity);
        Task<int> DeleteAsync(int id);
        Task<IReadOnlyList<Users>> GetAllAsync();
        Task<Users> GetByIdAsync(int id);
        Task<int> UpdateAsync(Users entity);
        Task<IReadOnlyList<Products>> GetProductAllAsync(int UserId);
    }
}