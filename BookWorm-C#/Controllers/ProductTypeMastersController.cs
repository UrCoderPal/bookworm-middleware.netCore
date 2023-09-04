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
    public class ProductTypeMastersController : ControllerBase
    {
        private readonly AppdbContext _context;

        public ProductTypeMastersController(AppdbContext context)
        {
            _context = context;
        }

        // GET: api/ProductTypeMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductTypeMaster>>> GetproductTypeMasters()
        {
          if (_context.productTypeMasters == null)
          {
              return NotFound();
          }
            return await _context.productTypeMasters.ToListAsync();
        }

        // GET: api/ProductTypeMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductTypeMaster>> GetProductTypeMaster(long id)
        {
          if (_context.productTypeMasters == null)
          {
              return NotFound();
          }
            var productTypeMaster = await _context.productTypeMasters.FindAsync(id);

            if (productTypeMaster == null)
            {
                return NotFound();
            }

            return productTypeMaster;
        }

        // PUT: api/ProductTypeMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductTypeMaster(long id, ProductTypeMaster productTypeMaster)
        {
            if (id != productTypeMaster.TypeId)
            {
                return BadRequest();
            }

            _context.Entry(productTypeMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductTypeMasterExists(id))
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

        // POST: api/ProductTypeMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductTypeMaster>> PostProductTypeMaster(ProductTypeMaster productTypeMaster)
        {
          if (_context.productTypeMasters == null)
          {
              return Problem("Entity set 'AppdbContext.productTypeMasters'  is null.");
          }
            _context.productTypeMasters.Add(productTypeMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductTypeMaster", new { id = productTypeMaster.TypeId }, productTypeMaster);
        }

        // DELETE: api/ProductTypeMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductTypeMaster(long id)
        {
            if (_context.productTypeMasters == null)
            {
                return NotFound();
            }
            var productTypeMaster = await _context.productTypeMasters.FindAsync(id);
            if (productTypeMaster == null)
            {
                return NotFound();
            }

            _context.productTypeMasters.Remove(productTypeMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductTypeMasterExists(long id)
        {
            return (_context.productTypeMasters?.Any(e => e.TypeId == id)).GetValueOrDefault();
        }
    }
}
