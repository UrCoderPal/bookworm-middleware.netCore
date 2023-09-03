using BookWorm_C_.Repositories;
using BookWormC.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using WebApplication1.Models;


namespace BookWormC.Repositories
{
    public class IAttributeMasterImpl : IAttributeMaster
    {
        private readonly Appdbcontext context;


        public IAttributeMasterImpl(Appdbcontext context)
        {
            this.context = context;
        }
        async Task<ActionResult> IAttributeMaster.addAttribute(AttributeMaster a)
        {
            context.AttributeMaster.Add(a);
            await context.SaveChangesAsync();
            return a;
        }

        async Task<ActionResult<IEnumerable>> IAttributeMaster.getAllAttribute()
        {
            if (context.AttributeMaster == null)
            {
                return null;
            }
            return await context.AttributeMaster.ToListAsync();
        }
    }

}