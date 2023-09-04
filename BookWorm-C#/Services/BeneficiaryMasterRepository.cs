using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookWorm_C_.Entities;
using BookWorm_C_.Repositories;

namespace BookWorm_C_.Services
{
    public class BeneficiaryMasterRepository : IBeneficiaryMaster
    {
        private readonly AppdbContext _context;

        public BeneficiaryMasterRepository(AppdbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<BeneficiaryMaster>> AddBeneficiary(BeneficiaryMaster ben)
        {
            _context.BeneficiaryMasters.Add(ben);
            await _context.SaveChangesAsync();
            return ben;
        }

        public async Task<BeneficiaryMaster> Delete(long benId)
        {
            var beneficiary = await _context.BeneficiaryMasters.FindAsync(benId);
            if (beneficiary == null)
            {
                return null;
            }

            _context.BeneficiaryMasters.Remove(beneficiary);
            await _context.SaveChangesAsync();
            return beneficiary;
        }

        public async Task<ActionResult<IEnumerable<BeneficiaryMaster>>> GetAllBen()
        {
            return await _context.BeneficiaryMasters.ToListAsync();
        }

        public async Task<ActionResult<BeneficiaryMaster>?> GetBen(long benId)
        {
            return await _context.BeneficiaryMasters.FindAsync(benId);
        }

        public async Task<BeneficiaryMaster> Update(long benId, BeneficiaryMaster ben)
        {
            if (benId != ben.BeneficiaryId)
            {
                throw new ArgumentException("Beneficiary Ids do not match.");
            }

            _context.Entry(ben).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BeneficiaryMasterExists(benId))
                {
                    return null;
                }
                throw;
            }

            return ben;
        }

        private bool BeneficiaryMasterExists(long benId)
        {
            return _context.BeneficiaryMasters.Any(e => e.BeneficiaryId == benId);
        }

        Task<ProductTypeMaster> IBeneficiaryMaster.Update(long BenId, BeneficiaryMaster ben)
        {
            throw new NotImplementedException();
        }
    }
}
