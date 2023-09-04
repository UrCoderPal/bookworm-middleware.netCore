using BookWorm_C_.Entities;
using BookWorm_C_.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookWorm_C_.Services
{

    public class SQLInvoiceTableRepository : IInvoiceTableRepository
    {
        private readonly BookWormContext context;

        public SQLInvoiceTableRepository(BookWormContext context)
        {
            this.context = context;
        }
        public async Task<ActionResult<InvoiceTable>> Add(InvoiceTable invoiceTable)
        {
            context.InvoiceTables.Add(invoiceTable);
            await context.SaveChangesAsync();
            return invoiceTable;
        }

        public async Task<InvoiceTable> Delete(int Id)
        {
            InvoiceTable invoicetable = context.InvoiceTables.Find(Id);
            if (invoicetable != null)
            {
                context.InvoiceTables.Remove(invoicetable);
                await context.SaveChangesAsync();
            }
            return invoicetable;
        }
        public async Task<ActionResult<IEnumerable<InvoiceTable>?>> getAllInvoiceTables()
        {
            if (context.InvoiceTables == null)
            {
                return null;
            }
            return await context.InvoiceTables.ToListAsync();

        }

        public async Task<ActionResult<InvoiceTable>?> GetEmployee(int Id)
        {
            if (context.InvoiceTables == null)
            {
                return null;
            }
            var invoicetable = await context.InvoiceTables.FindAsync(Id);

            if (invoicetable == null)
            {
                return null;
            }

            return invoicetable;

        }

        public InvoiceTable? GetInvoiceTable(int id)
        {
            return context.InvoiceTables.Find(id);
        }


        public async Task<InvoiceTable?> Update(int id, InvoiceTable invoiceTable)
        {
            if (id != invoiceTable.InvoiceTableId)
            {
                return null;
            }

            context.Entry(invoiceTable).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InoviceTableExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return null;

        }

        Task<InvoiceTable?> IInvoiceTableRepository.GetInovoiceTable(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<InvoiceTable?> GetInvoiceTableAsync(int id)
        {
            return await context.InvoiceTables.FindAsync(id);
        }

        private bool InoviceTableExists(int id)
        {
            return (context.InvoiceTables?.Any(e => e.InvoiceTableId == id)).GetValueOrDefault();
        }
    }
}