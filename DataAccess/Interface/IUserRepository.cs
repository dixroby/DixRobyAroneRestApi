using Dix.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Interface
{
    public interface IUserRepository
    {
        Task<int> AddAsync(Users entity);
        Task<int> DeleteAsync(int id);
        Task<IReadOnlyList<Users>> GetAllAsync();
        Task<Users> GetByIdAsync(int id);
        Task<int> UpdateAsync(Users entity);
        Task<IReadOnlyList<Products>> GetProductAllAsync(int UserId);
    }
}