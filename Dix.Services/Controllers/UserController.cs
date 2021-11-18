using Dix.Business.Interface;
using Dix.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dix.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserLogic _userLogic;

        public UserController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userLogic.GetAllAsync();
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<User> GetByIdAsync(int id)
        {
            return await _userLogic.GetByIdAsync(id);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<int> AddAsync([FromBody] User user)
        {
            return await _userLogic.AddAsync(user);
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<int> UpdateAsync([FromBody] User user)
        {
            return await _userLogic.UpdateAsync(user);
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<int> DeleteAsync(int id)
        {
            return await _userLogic.DeleteAsync(id);
        }
    }
}
