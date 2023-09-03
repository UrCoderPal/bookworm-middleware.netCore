using BookWorm_C_.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookWorm_C_.Repositories
{
    public interface IInvoiceDetailsRepository
    {
        Task<ActionResult<InvoiceDetail>?> GetInvoiceDetail(int Id);
        Task<ActionResult<IEnumerable<InvoiceDetail>>> GetAllInvoiceDetails();
        Task<ActionResult<InvoiceDetail>> AddInvoiceDatail(InvoiceDetail invoicedetail);
        Task<InvoiceDetail> UpdateinvoiceDetail(int id, InvoiceDetail employeeChanges);
        Task<InvoiceDetail> DeleteInvoiceDetail(int Id);
    }
}