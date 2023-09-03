using BookWorm_C_.Entities;
using Microsoft.AspNetCore.Mvc;
using BookWorm_C_.Repositories;

namespace BookWorm_C_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceDetailsController : ControllerBase
    {
        private readonly IInvoiceDetail _repository;

        public InvoiceDetailsController(IInvoiceDetail repository)
        {
            _repository = repository;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<IEnumerable<InvoiceDetail>>> GetAllInvoiceDetails()
        {
            var invoiceDetails = await _repository.getAllInvoiceDetails();
            if (invoiceDetails == null)
            {
                return NotFound();
            }
            return Ok(invoiceDetails);
        }

        [HttpGet("getById/{id}")]
        public async Task<ActionResult<InvoiceDetail>> GetInvoiceDetailById(long invDtlId)
        {
            var invoiceDetail = await _repository.getByInvDtlId(invDtlId);
            if (invoiceDetail == null)
            {
                return NotFound();
            }
            return Ok(invoiceDetail);
        }

        [HttpGet("tranType/{tranType}")]
        public async Task<ActionResult<InvoiceDetail>> GetByTranType(string tranType)
        {
            var invoiceDetail = await _repository.getByTranType(tranType);
            if (invoiceDetail == null)
            {
                return NotFound();
            }
            return Ok(invoiceDetail);
        }

        [HttpGet("baseprice/{basePrice}")]
        public async Task<ActionResult<InvoiceDetail>> GetByBasePrice(double basePrice)
        {
            var invoiceDetail = await _repository.getByBasePrice(basePrice);
            if (invoiceDetail == null)
            {
                return NotFound();
            }
            return Ok(invoiceDetail);
        }

        [HttpPost("add")]
        public async Task<ActionResult<InvoiceDetail>> AddInvoiceDetail(InvoiceDetail invdetails)
        {
            await _repository.setInvoiceDetails(invdetails);
            return CreatedAtAction("PostEmployee", new { id = invdetails.InvoiceDetailId }, invdetails);

        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<InvoiceDetail>> DeleteInvoiceDetailById(long id)
        {
            var invoiceDetail = await _repository.deleteInvoiceDetailsById(id);
            if (invoiceDetail == null)
            {
                return NotFound();
            }
            return Ok(invoiceDetail);
        }

        /*[HttpPut("updateQuantity/{id}")]
        public async Task<IActionResult> UpdateQuantity(long id, [FromBody] InvoiceDetail invdetails)
        {
            try
            {
                var updatedInvoiceDetail = await _repository.updateQuantity(id, invdetails);
                if (updatedInvoiceDetail == null)
                {
                    return NotFound();
                }
                return Ok(updatedInvoiceDetail);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("updateTranType/{id}")]
        public async Task<IActionResult> UpdateTranType(long id, [FromBody] InvoiceDetail invdetails)
        {
            try
            {
                var updatedInvoiceDetail = await _repository.updateTranType(id, invdetails);
                if (updatedInvoiceDetail == null)
                {
                    return NotFound();
                }
                return Ok(updatedInvoiceDetail);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }*/
    }
}
