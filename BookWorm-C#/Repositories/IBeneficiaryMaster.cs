using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using BookWorm_C_.Entities;

namespace BookWorm_C_.Repositories
{
    public interface IBeneficiaryMaster
    {
        Task<ActionResult<BeneficiaryMaster>> AddBeneficiary(BeneficiaryMaster ben);
        Task<ActionResult<IEnumerable<BeneficiaryMaster>>> GetAllBen();
        Task<BeneficiaryMaster> Delete(long BenId);
        Task<ActionResult<BeneficiaryMaster>?> GetBen(long BenId);
        Task<ProductTypeMaster> Update(long BenId, BeneficiaryMaster ben);

    }
}
