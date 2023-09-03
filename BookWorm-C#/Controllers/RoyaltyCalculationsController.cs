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
    public class RoyaltyCalculationsController : ControllerBase
    {
        private readonly BookWormContext _context;

        public RoyaltyCalculationsController(BookWormContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoyaltyCalculation>>> GetRoyaltyCalculations()
        {
            var royaltyCalculations = await _context.RoyaltyCalculations.ToListAsync();
            return Ok(royaltyCalculations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoyaltyCalculation>> GetRoyaltyCalculation(long id)
        {
            var royaltyCalculation = await _context.RoyaltyCalculations.FindAsync(id);

            if (royaltyCalculation == null)
            {
                return NotFound();
            }

            return Ok(royaltyCalculation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoyaltyCalculation(long id, RoyaltyCalculation royaltyCalculation)
        {
            if (id != royaltyCalculation.RoyaltyCalculationId)
            {
                return BadRequest();
            }

            _context.Entry(royaltyCalculation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoyaltyCalculationExists(id))
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
        public async Task<ActionResult<RoyaltyCalculation>> PostRoyaltyCalculation(RoyaltyCalculation royaltyCalculation)
        {
            _context.RoyaltyCalculations.Add(royaltyCalculation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoyaltyCalculation", new { id = royaltyCalculation.RoyaltyCalculationId }, royaltyCalculation);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoyaltyCalculation(long id)
        {
            var royaltyCalculation = await _context.RoyaltyCalculations.FindAsync(id);
            if (royaltyCalculation == null)
            {
                return NotFound();
            }

            _context.RoyaltyCalculations.Remove(royaltyCalculation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoyaltyCalculationExists(long id)
        {
            return _context.RoyaltyCalculations.Any(e => e.RoyaltyCalculationId == id);
        }
    }
}
