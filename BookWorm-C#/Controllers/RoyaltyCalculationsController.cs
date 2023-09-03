using BookWorm_C_.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookWorm_C_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoyaltyCalculationsController : ControllerBase
    {
        private readonly IRoyaltyCalculationRepository _repository;

        public RoyaltyCalculationsController(IRoyaltyCalculationRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoyaltyCalculation>>> GetRoyaltyCalculations()
        {
            var royaltyCalculations = await _repository.GetAllAsync();
            return Ok(royaltyCalculations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoyaltyCalculation>> GetRoyaltyCalculation(long id)
        {
            var royaltyCalculation = await _repository.GetByIdAsync(id);
            if (royaltyCalculation == null)
                return NotFound();

            return Ok(royaltyCalculation);
        }

        [HttpPost]
        public async Task<ActionResult<RoyaltyCalculation>> PostRoyaltyCalculation(RoyaltyCalculation royaltyCalculation)
        {
            var createdRoyaltyCalculation = await _repository.CreateAsync(royaltyCalculation);
            return CreatedAtAction(nameof(GetRoyaltyCalculation), new { id = createdRoyaltyCalculation.RoyaltyCalculationId }, createdRoyaltyCalculation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoyaltyCalculation(long id, RoyaltyCalculation royaltyCalculation)
        {
            var updatedRoyaltyCalculation = await _repository.UpdateAsync(id, royaltyCalculation);
            if (updatedRoyaltyCalculation == null)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoyaltyCalculation(long id)
        {
            var result = await _repository.DeleteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
