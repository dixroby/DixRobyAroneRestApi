using DataAccess.Repository;
using Dix.Business.Interface;
using Dix.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dix.Business.Logic
{
    public class BuyProductLogic : IBuyProductLogic
    {
        private readonly IBuyProductRepository _buyProductRepository;

        public BuyProductLogic(IBuyProductRepository buyProductRepository)
        {
            _buyProductRepository = buyProductRepository;
        }

        public async Task<int> AddAsync(BuyProducts entity)
        {
            entity.DateCreated = DateTime.Now;
            return await _buyProductRepository.AddAsync(entity);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _buyProductRepository.DeleteAsync(id);
        }

        public async Task<IReadOnlyList<BuyProducts>> GetAllAsync()
        {
            return await _buyProductRepository.GetAllAsync();
        }

        public async Task<BuyProducts> GetByIdAsync(int id)
        {
            return await _buyProductRepository.GetByIdAsync(id);
        }

        public async Task<int> UpdateAsync(BuyProducts entity)
        {
            return await _buyProductRepository.UpdateAsync(entity);
        }
    }
}