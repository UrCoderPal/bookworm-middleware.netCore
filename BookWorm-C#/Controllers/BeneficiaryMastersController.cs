using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ebookproject.Models;

namespace Ebookproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeneficiaryMastersController : ControllerBase
    {
        private readonly AppdbContext _context;

        public BeneficiaryMastersController(AppdbContext context)
        {
            _context = context;
        }

        // GET: api/BeneficiaryMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BeneficiaryMaster>>> GetBeneficiaryMasters()
        {
          if (_context.BeneficiaryMasters == null)
          {
              return NotFound();
          }
            return await _context.BeneficiaryMasters.ToListAsync();
        }

        // GET: api/BeneficiaryMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BeneficiaryMaster>> GetBeneficiaryMaster(long id)
        {
          if (_context.BeneficiaryMasters == null)
          {
              return NotFound();
          }
            var beneficiaryMaster = await _context.BeneficiaryMasters.FindAsync(id);

            if (beneficiaryMaster == null)
            {
                return NotFound();
            }

            return beneficiaryMaster;
        }

        // PUT: api/BeneficiaryMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{Benid}")]
        public async Task<IActionResult> PutBeneficiaryMaster(long Benid, BeneficiaryMaster beneficiaryMaster)
        {
            if (Benid != beneficiaryMaster.BenId)
            {
                return BadRequest();
            }

            _context.Entry(beneficiaryMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BeneficiaryMasterExists(Benid))
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

        // POST: api/BeneficiaryMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BeneficiaryMaster>> PostBeneficiaryMaster(BeneficiaryMaster beneficiaryMaster)
        {
          if (_context.BeneficiaryMasters == null)
          {
              return Problem("Entity set 'AppdbContext.BeneficiaryMasters'  is null.");
          }
            _context.BeneficiaryMasters.Add(beneficiaryMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBeneficiaryMaster", new { id = beneficiaryMaster.BenId }, beneficiaryMaster);
        }

        // DELETE: api/BeneficiaryMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBeneficiaryMaster(long id)
        {
            if (_context.BeneficiaryMasters == null)
            {
                return NotFound();
            }
            var beneficiaryMaster = await _context.BeneficiaryMasters.FindAsync(id);
            if (beneficiaryMaster == null)
            {
                return NotFound();
            }

            _context.BeneficiaryMasters.Remove(beneficiaryMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BeneficiaryMasterExists(long id)
        {
            return (_context.BeneficiaryMasters?.Any(e => e.BenId == id)).GetValueOrDefault();
        }
    }
}
