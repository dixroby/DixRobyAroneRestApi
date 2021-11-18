using Dix.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dix.Business.Interface
{
    public interface IBuyProductLogic
    {
        Task<int> AddAsync(BuyProducts entity);
        Task<int> DeleteAsync(int id);
        Task<IReadOnlyList<BuyProducts>> GetAllAsync();
        Task<BuyProducts> GetByIdAsync(int id);
        Task<int> UpdateAsync(BuyProducts entity);
    }
}