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
    public class UsuariosController : ControllerBase
    {
        private readonly IUserLogic _userLogic;

        public UsuariosController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        // GET: api/<UsuariosController>
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _userLogic.GetAllAsync();
        }

        // GET api/<UsuariosController>/5
        [HttpGet("{id}")]
        public async Task<User> Get(int id)
        {
            return await _userLogic.GetByIdAsync(id);
        }

        // POST api/<UsuariosController>
        [HttpPost]
        public async Task<int> Post([FromBody] User user)
        {
            return await _userLogic.AddAsync(user);
        }

        // PUT api/<UsuariosController>
        [HttpPut]
        public async Task<int> Put([FromBody] User user)
        {
            return await _userLogic.UpdateAsync(user);
        }

        // DELETE api/<UsuariosController>/5
        [HttpDelete("{id}")]
        public async Task<int> Delete(int id)
        {
            return await _userLogic.DeleteAsync(id);
        }
    }
}
