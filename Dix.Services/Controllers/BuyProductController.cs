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
    public class BuyProductController : ControllerBase
    {
        private readonly IBuyProductLogic _buyProductLogic;

        public BuyProductController(IBuyProductLogic buyProductLogic)
        {
            _buyProductLogic = buyProductLogic;
        }

        // GET: api/<ProductController>
        [HttpGet]
        [Route("[action]")]
        public async Task<IEnumerable<BuyProducts>> GetAllAsync()
        {
            return await _buyProductLogic.GetAllAsync();
        }

        // GET api/<ProductController>/5
        [HttpGet]
        [Route("[action]")]
        public async Task<BuyProducts> GetByIdAsync(int id)
        {
            return await _buyProductLogic.GetByIdAsync(id);
        }

        // POST api/<ProductController>
        [HttpPost]
        [Route("[action]")]
        public async Task<int> AddAsync([FromBody] BuyProducts buyProducts)
        {
            return await _buyProductLogic.AddAsync(buyProducts);
        }

        // PUT api/<ProductController>
        [HttpPut]
        [Route("[action]")]
        public async Task<int> UpdateAsync([FromBody] BuyProducts buyProduct)
        {
            return await _buyProductLogic.UpdateAsync(buyProduct);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete]
        [Route("[action]")]
        public async Task<int> DeleteAsync(int id)
        {
            return await _buyProductLogic.DeleteAsync(id);
        }
    }
}
