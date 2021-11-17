using DataAccess.Interface;
using Dix.Business.Helper;
using Dix.Business.Interface;
using Dix.Dto;
using System.Collections.Generic;
using System.Security.Cryptography;
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

        public async Task<int> AddAsync(User entity)
        {
            using (Rijndael myRijndael = Rijndael.Create())
            {
                string encrypted = HelperPassword.EncryptString(entity.Password, myRijndael.Key, myRijndael.IV);

                entity.Password = encrypted;
            }
            return await _userRepository.AddAsync(entity);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _userRepository.DeleteAsync(id);
        }

        public async Task<IReadOnlyList<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<int> UpdateAsync(User entity)
        {
            return await _userRepository.UpdateAsync(entity);
        }
    }
}