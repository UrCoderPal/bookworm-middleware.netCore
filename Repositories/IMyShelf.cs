using BookWorm_C_.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookWorm_C_.Repositories
{
    public interface IMyShelf
    {
        Task<ActionResult<MyShelf>?> getById(long MyShelfId);
        Task<ActionResult<MyShelf>?> getByCustomerId(long CustomerId);
    }
}
