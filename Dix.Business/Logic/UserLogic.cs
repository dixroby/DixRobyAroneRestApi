using DataAccess.Interface;
using Dix.Business.Interface;
using Dix.Dto;
using Dix.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dix.Business.Logic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserRepository _userRepository;

        public UserLogic(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> AddAsync(Users entity)
        {
            if (!string.IsNullOrEmpty(entity.Password))
                entity.Password = Cryptography.EncriptarAES(entity.Password);
            return await _userRepository.AddAsync(entity);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _userRepository.DeleteAsync(id);
        }

        public async Task<IReadOnlyList<Users>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<Users> GetByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<int> UpdateAsync(Users entity)
        {
            return await _userRepository.UpdateAsync(entity);
        }

        public async Task<IReadOnlyList<Products>> GetProductAllAsync(int UserId)
        {
            return await _userRepository.GetProductAllAsync(UserId);
        }
    }
}