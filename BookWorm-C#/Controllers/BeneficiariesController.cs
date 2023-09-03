using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeneficiariesController : ControllerBase
    {
        private readonly BookWormContext _context;

        public BeneficiariesController(BookWormContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Beneficiary>>> GetBeneficiaries()
        {
            var beneficiaries = await _context.Beneficiarys.ToListAsync();
            return Ok(beneficiaries);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Beneficiary>> GetBeneficiary(long id)
        {
            var beneficiary = await _context.Beneficiarys.FindAsync(id);

            if (beneficiary == null)
            {
                return NotFound();
            }

            return Ok(beneficiary);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBeneficiary(long id, Beneficiary beneficiary)
        {
            if (id != beneficiary.BeneficiaryId)
            {
                return BadRequest();
            }

            _context.Entry(beneficiary).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BeneficiaryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Beneficiary>> PostBeneficiary(Beneficiary beneficiary)
        {
            _context.Beneficiarys.Add(beneficiary);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBeneficiary", new { id = beneficiary.BeneficiaryId }, beneficiary);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBeneficiary(long id)
        {
            var beneficiary = await _context.Beneficiarys.FindAsync(id);
            if (beneficiary == null)
            {
                return NotFound();
            }

            _context.Beneficiarys.Remove(beneficiary);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BeneficiaryExists(long id)
        {
            return _context.Beneficiarys.Any(e => e.BeneficiaryId == id);
        }
    }
}
