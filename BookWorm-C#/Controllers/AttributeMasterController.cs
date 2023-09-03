using BookWorm_C_.Repositories;
using BookWormC.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BookWorm_C_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttributeMasterController : ControllerBase
    {
        private readonly IAttributeMaster _repository;

        public AttributeMasterController(IAttributeMaster repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AttributeMaster>> GetAllAttributes()
        {
            var a = _repository.getAllAttribute();

            if (a == null )
            {
                return NotFound();
            }

            return Ok(a);
        }

        [HttpPost]
        public ActionResult<AttributeMaster> PostAttribute(AttributeMaster a)
        {
            _repository.addAttribute(a);

            return CreatedAtAction(nameof(GetAllAttributes), new { id = a.AttributeMasterId }, a);
        }
    }
}