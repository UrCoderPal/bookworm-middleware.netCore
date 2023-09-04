using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookWorm_C_.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookWorm_C_.Repositories
{
    public interface IAttributeMaster
    {
        Task<ActionResult<IEnumerable>> getAllAttribute();
        Task<ActionResult<AttributeMaster>> addAttribute(AttributeMaster a);
    }
}