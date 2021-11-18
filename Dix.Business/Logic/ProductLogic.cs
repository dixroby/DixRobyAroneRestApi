using DataAccess.Repository;
using Dix.Business.Interface;
using Dix.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dix.Business.Logic
{
    public class ProductLogic : IProductLogic
    {
        private readonly IProductRepository _productRepository;

        public ProductLogic(IProductRepository userRepository)
        {
            _productRepository = userRepository;
        }

        public async Task<int> AddAsync(Products entity)
        {
            return await _productRepository.AddAsync(entity);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _productRepository.DeleteAsync(id);
        }

        public async Task<IReadOnlyList<Products>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Products> GetByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task<int> UpdateAsync(Products entity)
        {
            return await _productRepository.UpdateAsync(entity);
        }
    }
}