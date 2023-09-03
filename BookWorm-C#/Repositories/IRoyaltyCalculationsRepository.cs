using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookWorm_C_.Entities
{
    public interface IRoyaltyCalculationRepository
    {
        Task<IEnumerable<RoyaltyCalculation>> GetAllAsync();
        Task<RoyaltyCalculation> GetByIdAsync(long id);
        Task<RoyaltyCalculation> CreateAsync(RoyaltyCalculation royaltyCalculation);
        Task<RoyaltyCalculation> UpdateAsync(long id, RoyaltyCalculation royaltyCalculation);
        Task<bool> DeleteAsync(long id);
    }
}