using BookWorm_C_.Entities;
using BookWorm_C_.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookWorm_C_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceTableController : ControllerBase
    {
        private readonly IInvoiceTableRepository _repository;

        public InvoiceTableController(IInvoiceTableRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("/GetAllInvoiceTables")]
        public async Task<ActionResult<IEnumerable<InvoiceTable>>> GetAllInvoiceTables()
        {
            var invoiceTables = await _repository.getAllInvoiceTables();

            if (invoiceTables == null)
            {
                return NotFound();
            }

            return Ok(invoiceTables);
        }

        [HttpGet("/GetInvoiceTable/{id}")]
        public async Task<ActionResult<InvoiceTable>> GetInvoiceTableById(int id)
        {
            var invoiceTable = await _repository.GetInvoiceTableAsync(id);

            if (invoiceTable == null)
            {
                return NotFound();
            }

            return Ok(invoiceTable);
        }

        [HttpPut(("/UpdateInvoiceTable/{id}"))]
        public async Task<IActionResult> UpdateInvoiceTable(int id, InvoiceTable invoice)
        {
            if (id != invoice.InvoiceTableId)
            {
                return BadRequest();
            }

            try
            {
                await _repository.Update(id, invoice);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_repository.GetInvoiceTableAsync(id) == null)
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

        [HttpPost("/AddInvoiceTable")]
        public async Task<ActionResult<InvoiceTable>> CreateInvoiceTable(InvoiceTable invoice)
        {
            await _repository.Add(invoice);

            return CreatedAtAction(nameof(GetInvoiceTableById), new { id = invoice.InvoiceTableId }, invoice);
        }

        [HttpDelete("/DeleteInvoiceTable/{id}")]
        public async Task<IActionResult> DeleteInvoiceTable(int id)
        {
            var invoiceTable = await _repository.GetInvoiceTableAsync(id);

            if (invoiceTable == null)
            {
                return NotFound();
            }

            await _repository.Delete(id);

            return NoContent();
        }
    }
}