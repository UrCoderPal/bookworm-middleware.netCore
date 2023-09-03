using BookWorm_C_.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookWorm_C_.Repositories
{
    public interface IInvoiceTableRepository
    {
        Task<InvoiceTable?> GetInvoiceTableAsync(int id);
        Task<ActionResult<IEnumerable<InvoiceTable>>> getAllInvoiceTables();
        Task<InvoiceTable?> GetInovoiceTable(int id);
        Task<ActionResult<InvoiceTable>> Add(InvoiceTable invoicetable);
        Task<InvoiceTable> Update(int id, InvoiceTable invoicetable);
        Task<InvoiceTable> Delete(int Id);
    }
}