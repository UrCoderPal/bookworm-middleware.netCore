using BookWorm_C_.Entities;
using BookWorm_C_.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookWorm_C_.Services
{
    public class SQLInvoiceDetailRepository : IInvoiceDetailsRepository
    {
        private readonly BookWormContext _context;

        public SQLInvoiceDetailRepository(BookWormContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<InvoiceDetail>?> GetInvoiceDetail(int Id)
        {
            var invoiceDetail = await _context.InvoiceDetails.FindAsync(Id);

            if (invoiceDetail == null)
            {
                return null;
            }

            return invoiceDetail;
        }

        public async Task<ActionResult<IEnumerable<InvoiceDetail>>> GetAllInvoiceDetails()
        {

            var invoiceDetails = await _context.InvoiceDetails.ToListAsync();

            return invoiceDetails;
        }

        public async Task<ActionResult<InvoiceDetail>> AddInvoiceDatail(InvoiceDetail invoicedetail)
        {

            _context.InvoiceDetails.Add(invoicedetail);
            await _context.SaveChangesAsync();

            return invoicedetail;
        }

        public async Task<InvoiceDetail> UpdateinvoiceDetail(int id, InvoiceDetail invoiceDetailChanges)
        {

            if (id != invoiceDetailChanges.InvoiceDetailId)
            {
                return null;
            }

            _context.Entry(invoiceDetailChanges).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceDetailExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return invoiceDetailChanges;
        }

        public async Task<InvoiceDetail> DeleteInvoiceDetail(int Id)
        {
            var invoiceDetail = await _context.InvoiceDetails.FindAsync(Id);

            if (invoiceDetail == null)
            {
                return null;
            }

            _context.InvoiceDetails.Remove(invoiceDetail);
            await _context.SaveChangesAsync();

            return invoiceDetail;
        }

        private bool InvoiceDetailExists(int id)
        {

            return _context.InvoiceDetails.Any(e => e.InvoiceDetailId == id);
        }
    }
}