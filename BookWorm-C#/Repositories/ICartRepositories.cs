using System.Collections.Generic;
using BookWorm_C_.Entities;

namespace BookWorm_C_.Repositories
{
    public interface ICartRepository
    {
        IEnumerable<Cart> GetAllCarts();
        void AddCart(Cart cart);
    }
}