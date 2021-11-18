using Dix.Business.Interface;
using Dix.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// api para CRUD de productos

namespace Dix.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductLogic _productLogic;

        public ProductController(IProductLogic productLogic)
        {
            _productLogic = productLogic;
        }

        // GET: api/<ProductController>
        [HttpGet]
        [Route("[action]")]
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _productLogic.GetAllAsync();
        }

        // GET api/<ProductController>/5
        [HttpGet]
        [Route("[action]")]
        public async Task<Product> GetByIdAsync(int id)
        {
            return await _productLogic.GetByIdAsync(id);
        }

        // POST api/<ProductController>
        [HttpPost]
        [Route("[action]")]
        public async Task<int> AddAsync([FromBody] Product user)
        {
            return await _productLogic.AddAsync(user);
        }

        // PUT api/<ProductController>
        [HttpPut]
        [Route("[action]")]
        public async Task<int> UpdateAsync([FromBody] Product user)
        {
            return await _productLogic.UpdateAsync(user);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete]
        [Route("[action]")]
        public async Task<int> DeleteAsync(int id)
        {
            return await _productLogic.DeleteAsync(id);
        }
    }
}
