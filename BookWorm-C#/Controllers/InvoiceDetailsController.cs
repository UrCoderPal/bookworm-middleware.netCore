using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookWorm_C_.Entities;
using BookWorm_C_.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookWorm_C_.Controllers
{
    [Route("api/[controller]")
    [ApiController]
    public class InvoiceDetailController : ControllerBase
    {
        private readonly IInvoiceDetailsRepository _repository;

        public InvoiceDetailController(IInvoiceDetailsRepository repository)
        {
            _repository = repository;
        }

        // GET: api/InvoiceDetail
        [HttpGet("/GetAllInvoiceDetail")]
        public async Task<ActionResult<IEnumerable<InvoiceDetail>>> Get()
        {
            var invoiceDetails = await _repository.GetAllInvoiceDetails();
            return Ok(invoiceDetails.Value);
        }


        [HttpGet("/GetInvoiceDetail/{id}")]
        public async Task<ActionResult<InvoiceDetail>> Get(int id)
        {
            var invoiceDetail = await _repository.GetInvoiceDetail(id);

            if (invoiceDetail == null)
            {
                return NotFound();
            }

            return Ok(invoiceDetail.Value);
        }

        // POST api/InvoiceDetail
        [HttpPost]
        public async Task<ActionResult<InvoiceDetail>> Post([FromBody] InvoiceDetail invoiceDetail)
        {
            var addedInvoiceDetail = await _repository.AddInvoiceDatail(invoiceDetail);
            return CreatedAtAction(nameof(Get), new { id = addedInvoiceDetail.Value.Id }, addedInvoiceDetail.Value);
        }


        [HttpPut("/UpdateInvoiceDetail/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] InvoiceDetail invoiceDetail)
        {
            var updatedInvoiceDetail = await _repository.UpdateinvoiceDetail(id, invoiceDetail);

            if (updatedInvoiceDetail == null)
            {
                return NotFound();
            }

            return NoContent();
        }


        [HttpDelete("/DeleteInvoiceDetail/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedInvoiceDetail = await _repository.DeleteInvoiceDetail(id);

            if (deletedInvoiceDetail == null)
            {
                return NotFound();
            }

            return NoContent();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceDetail>> GetInvoiceById(int id)
        {
            var invoiceDetail = await _repository.GetInvoiceDetail(id);

            if (invoiceDetail == null)
            {
                return NotFound();
            }

            return Ok(invoiceDetail.Value);
        }

    }
}