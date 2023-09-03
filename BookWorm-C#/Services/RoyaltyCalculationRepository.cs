using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookWorm_C_.Repositories;

namespace BookWorm_C_.Entities
{
    public class RoyaltyCalculationRepository : IRoyaltyCalculationRepository
    {
        private readonly AppdbContext _context;

        public RoyaltyCalculationRepository(AppdbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RoyaltyCalculation>> GetAllAsync()
        {
            return await _context.RoyaltyCalculations.ToListAsync();
        }

        public async Task<RoyaltyCalculation> GetByIdAsync(long id)
        {
            return await _context.RoyaltyCalculations.FindAsync(id);
        }

        public async Task<RoyaltyCalculation> CreateAsync(RoyaltyCalculation royaltyCalculation)
        {
            _context.RoyaltyCalculations.Add(royaltyCalculation);
            await _context.SaveChangesAsync();
            return royaltyCalculation;
        }

        public async Task<RoyaltyCalculation> UpdateAsync(long id, RoyaltyCalculation royaltyCalculation)
        {
            if (id != royaltyCalculation.RoyaltyCalculationId)
                throw new ArgumentException("Invalid ID");

            _context.Entry(royaltyCalculation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoyaltyCalculationExists(id))
                    return null;
                else
                    throw;
            }

            return royaltyCalculation;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var royaltyCalculation = await _context.RoyaltyCalculations.FindAsync(id);
            if (royaltyCalculation == null)
                return false;

            _context.RoyaltyCalculations.Remove(royaltyCalculation);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool RoyaltyCalculationExists(long id)
        {
            return _context.RoyaltyCalculations.Any(e => e.RoyaltyCalculationId == id);
        }
    }
}
