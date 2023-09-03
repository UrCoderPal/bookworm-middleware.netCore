using Microsoft.AspNetCore.Mvc;

namespace BookWorm_C_.Repositories
{
    public interface IProductTypeMaster
    {
        Task<ActionResult<IEnumerable<ProductTypeMaster>>> GetAllProducts();
        Task<ActionResult<ProductTypeMaster>> Add(ProductTypeMaster Pro);
        Task<ProductTypeMaster> Delete(long TypeId);
        Task<ProductTypeMaster> Update(long TypeId, ProductTypeMaster Pro);
        Task<ActionResult<ProductTypeMaster>?> GetProduct( long TypeId);
       
       
       
       
        
    }
}
