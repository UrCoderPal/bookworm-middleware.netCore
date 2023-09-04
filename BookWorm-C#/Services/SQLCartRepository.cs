using System;
using System.Collections.Generic;
using System.Linq;
using BookWorm_C_.Entities;
using BookWorm_C_.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookWorm_C_.Services
{
    public class CartRepository : ICartRepository
    {
        private readonly BookWormContext _dbContext;

        public CartRepository(BookWormContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Cart> GetAllCarts()
        {
            return _dbContext.Carts
                .Include(c => c.CustomerCustomer)
                .Include(c => c.ProductProduct)
                .ToList();
        }



        public void AddCart(Cart cart)
        {
            _dbContext.Carts.Add(cart);
            _dbContext.SaveChanges();
        }
    }
}