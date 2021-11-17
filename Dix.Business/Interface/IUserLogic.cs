using Dix.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dix.Business.Interface
{
    public interface IUserLogic
    {
        Task<int> AddAsync(User entity);
        Task<int> DeleteAsync(int id);
        Task<IReadOnlyList<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task<int> UpdateAsync(User entity);
    }
}