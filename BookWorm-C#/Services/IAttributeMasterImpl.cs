using BookWorm_C_.Repositories;
using BookWorm_C_.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;


namespace BookWormC.Repositories
{
    public class AttributeMasterImpl : IAttributeMaster
    {
        private readonly AppdbContext context;


        public AttributeMasterImpl(AppdbContext context)
        {
            this.context = context;
        }
        async Task<ActionResult<AttributeMaster>> IAttributeMaster.addAttribute(AttributeMaster a)
        {
            context.AttributeMasters.Add(a);
            await context.SaveChangesAsync();
            return a;
        }

        async Task<ActionResult<IEnumerable>> IAttributeMaster.getAllAttribute()
        {
            if (context.AttributeMasters == null)
            {
                return null;
            }
            return await context.AttributeMasters.ToListAsync();
        }
    }

}