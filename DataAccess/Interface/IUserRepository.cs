using Dix.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Interface
{
    public interface IUserRepository
    {
        Task<int> AddAsync(User entity);
        Task<int> DeleteAsync(int id);
        Task<IReadOnlyList<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task<int> UpdateAsync(User entity);
    }
}