using BookWorm_C_.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace BookWorm_C_.Repositories
{
    public class IMyShelfImpl : IMyShelf
    {
        private readonly Appdbcontext context;

        public IMyShelfImpl(Appdbcontext context)
        {
            this.context = context;
        }

        public async Task<ActionResult<MyShelf>?> getByCustomerId(long CustomerId)
        {
            if (context.MyShelf == null)
            {
                return null;
            }
            var myshelf = await context.MyShelf.FindAsync(CustomerId);

            if (myshelf == null)
            {
                return null;
            }

            return myshelf;
        }

        public async Task<ActionResult<MyShelf>?> getById(long MyShelfId)
        {
            MyShelf myshelf = context.MyShelf.Find(MyShelfId);
            if (myshelf != null)
            {
                context.MyShelf.Remove(myshelf);
                await context.SaveChangesAsync();
            }
            return myshelf;
        }
    }
}
