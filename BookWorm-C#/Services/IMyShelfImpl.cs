using BookWorm_C_.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using BookWorm_C_.Repositories;
namespace BookWorm_C_.Services
{
    public class IMyShelfImpl : IMyShelf
    {
        private readonly AppdbContext context;

        public IMyShelfImpl(AppdbContext context)
        {
            this.context = context;
        }

        public async Task<ActionResult<MyShelf>?> getByCustomerId(long CustomerId)
        {
            if (context.MyShelves == null)
            {
                return null;
            }
            var myshelf = await context.MyShelves.FindAsync(CustomerId);

            if (myshelf == null)
            {
                return null;
            }

            return myshelf;
        }

        public async Task<ActionResult<MyShelf>?> getById(long MyShelfId)
        {
            MyShelf myshelf = context.MyShelves.Find(MyShelfId);
            if (myshelf != null)
            {
                context.MyShelves.Remove(myshelf);
                await context.SaveChangesAsync();
            }
            return myshelf;
        }
    }
}